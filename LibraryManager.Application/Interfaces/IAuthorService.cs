using LibraryManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Application.Interfaces
{
    public interface IAuthorService
    {
        void AddAuthor(Author author);
        IList<Author> GetAllAuthors();
    }
}
