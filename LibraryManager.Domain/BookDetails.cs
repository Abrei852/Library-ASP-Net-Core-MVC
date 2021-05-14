using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.Domain
{
    public class BookDetails
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        [Required] public Status Status { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
    }
}
