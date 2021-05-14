using LibraryManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface ILoanHistoryService
    {
        IEnumerable<LoanHistory> GetAll();
        IEnumerable<LoanHistory> GetForBook(BookDetails book);
        IEnumerable<LoanHistory> GetForMember(Member member);
        LoanHistory Get(int id);
        void Add(LoanHistory newLoanHistory);
    }
}
