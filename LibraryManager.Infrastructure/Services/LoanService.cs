using LibraryManager.Application.Interfaces;
using LibraryManager.Domain;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManager.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Loan newLoan)
        {
            _context.Add(newLoan);
            _context.SaveChanges();
        }

        public Loan Get(int id)
        {
            return _context.Loans.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Loan> GetAll()
        {
            return _context.Loans;
        }

        public Loan GetLatestLoan(int id)
        {
            return _context.Loans
                .Where(c => c.BorrowedBook.Id == id)
                .OrderByDescending(c => c.StartLoan)
                .FirstOrDefault();
        }

        public IEnumerable<LoanHistory> GetLoanHistory(int id)
        {
            return _context.LoanHistories
                .Include(a => a.BookDetails)
                .Include(a => a.Member)
                .Where(a => a.BookDetails.ID == id);
        }

        public bool IsLoanedOut(int id)
        {
            var isLoanedOut = _context.Loans.Any(a => a.BorrowedBook.Id == id);

            return isLoanedOut;
        }

        public void LoanOut(int id, string ssn)
        {
            if (IsLoanedOut(id)) return;

            var book = _context.BookDetails
                .Include(a => a.Status)
                .First(a => a.ID == id);

            _context.Update(book);

            book.Status = _context.Statuses
                .FirstOrDefault(a => a.Name == "Loaned Out");

            var now = DateTime.Now;

            var member = _context.Members
                .Include(x => x.BorrowedBooks)
                .FirstOrDefault(a => a.SSN == ssn);

            var loan = new Loan
            {
                BorrowedBook = book,
                BorrowingMember = member,
                StartLoan = now,
                EndLoan = GetDefaultLoanTime(now)
            };

            _context.Add(loan);

            var loanHistory = new LoanHistory
            {
                LoanedOut = now,
                BookDetails = book,
                Member = member
            };

            _context.Add(loanHistory);
            _context.SaveChanges();
        }

        private DateTime GetDefaultLoanTime(DateTime now)
        {
            return now.AddDays(14);
        }

        public void ReturnLoan(int id)
        {
            var now = DateTime.Now;

            var item = _context.BookDetails
                .First(a => a.ID == id);

            _context.Update(item);

            // remove any existing checkouts on the item
            var loan = _context.Loans
                .Include(c => c.BorrowedBook)
                .Include(c => c.BorrowingMember)
                .FirstOrDefault(a => a.BorrowedBook.Id == id);
            if (loan != null) _context.Remove(loan);

            // close any existing checkout history
            var history = _context.LoanHistories
                .Include(h => h.BookDetails)
                .Include(h => h.Member)
                .FirstOrDefault(h =>
                    h.BookDetails.ID == id
                    && h.Returned == null);
            if (history != null)
            {
                _context.Update(history);
                history.Returned = now;
            }

            // otherwise, set item status to available
            item.Status = _context.Statuses.FirstOrDefault(a => a.Name == "Available");

            _context.SaveChanges();
        }
    }
}
