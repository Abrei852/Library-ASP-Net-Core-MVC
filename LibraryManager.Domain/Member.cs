using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryManager.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Book> BorrowedBooks { get; set; }
    }
}
