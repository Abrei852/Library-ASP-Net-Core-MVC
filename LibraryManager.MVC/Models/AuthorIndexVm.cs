using LibraryManager.Domain;
using LibraryManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.MVC.Models
{
    public class AuthorIndexVm
    {
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
