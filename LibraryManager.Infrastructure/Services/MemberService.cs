using LibraryManager.Application.Interfaces;
using LibraryManager.Domain;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
        }

        public Member Get(int id)
        {
            return _context.Members
                .Include(a => a.BorrowedBooks)
                .Include(a => a.SSN)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members
                .Include(a => a.BorrowedBooks)
                .Include(a => a.SSN);
            // Eager load this data.
        }

        public IEnumerable<LoanHistory> GetLoanHistory(int memberId)
        {
            var loanId = _context.Members
                .Include(a => a.SSN)
                .FirstOrDefault(a => a.Id == memberId)?
                .SSN;

            return _context.LoanHistories
                .Include(a => a.Member)
                .Include(a => a.BookDetails)
                .Where(a => a.Member.SSN == loanId)
                .OrderByDescending(a => a.LoanedOut);
        }

        public IEnumerable<Loan> GetLoans(int id)
        {
            var memberLoanId = Get(id).Id;
            return _context.Loans
                .Include(a => a.BorrowingMember)
                .Include(a => a.BorrowedBook)
                .Where(v => v.Id == memberLoanId);
        }


    }
}
