using LibraryManager.Domain;
using System.Collections.Generic;

namespace LibraryManager.Application.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        Member Get(int id);
        void Add(Member member);
        IEnumerable<LoanHistory> GetLoanHistory(int memberId);
        IEnumerable<Loan> GetLoans(int id);
    }
}
