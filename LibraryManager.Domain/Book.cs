using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public BookDetails Books { get; set; }

        public static implicit operator Book(BookDetails v)
        {
            throw new NotImplementedException();
        }
    }
}