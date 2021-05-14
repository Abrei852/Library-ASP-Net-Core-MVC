using LibraryManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface ILoanService
    {
        IEnumerable<Loan> GetAll();
        Loan Get(int id);
        void Add(Loan newLoan);

        IEnumerable<LoanHistory> GetLoanHistory(int id);
        Loan GetLatestLoan(int id);
        void LoanOut(int id, string ssn);
        void ReturnLoan(int id);
        bool IsLoanedOut(int id);
    }
}
