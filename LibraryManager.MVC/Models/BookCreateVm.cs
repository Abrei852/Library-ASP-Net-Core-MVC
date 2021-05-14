using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.MVC.Models
{
    public class BookCreateVm
    {
        [Required]
        [Display(Name = "ISBN")]
        [MaxLength(10), MinLength(10)]
        public string ISBN { get; set; }
        [Display(Name = "Titel")]
        [MinLength(3)]
        public string Title { get; set; }
        [Display(Name = "Författare")]
        public SelectList AuthorList { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
    }
}
