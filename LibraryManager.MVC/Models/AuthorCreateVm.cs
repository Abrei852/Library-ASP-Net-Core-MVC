using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.MVC.Models
{
    public class AuthorCreateVm
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "Namn")]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}