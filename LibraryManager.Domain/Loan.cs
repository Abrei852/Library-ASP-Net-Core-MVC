using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain
{
    public class Loan
    {
            public int Id { get; set; }
            public Book BorrowedBook { get; set; }
            public Member BorrowingMember { get; set; }
            public DateTime StartLoan { get; set; }
            public DateTime EndLoan { get; set; }
    }
}
