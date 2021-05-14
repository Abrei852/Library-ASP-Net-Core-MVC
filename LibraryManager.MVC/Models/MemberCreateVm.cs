using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.MVC.Models
{
    public class MemberCreateVm
    {
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Example: Doe")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "{0} needs to be between 1 and 25 characters.")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Example: John")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} needs to be between 3 and 15 characters.")]
        public string FirstName { get; set; }
        [Display(Name = "SSN")]
        [Required(ErrorMessage = "Example: 970324-7721")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} needs to be 11 characters.")]
        public string SSN { get; set; }
    }
}
