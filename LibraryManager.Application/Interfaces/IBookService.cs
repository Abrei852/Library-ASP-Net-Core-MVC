using LibraryManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookDetails book);
        void UpdateBookDetails(BookDetails book);
        void UpdateBookDetails(int id, BookDetails book);
        ICollection<BookDetails> GetAllBooks();

    }
}
