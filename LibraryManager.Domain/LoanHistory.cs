using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.Domain
{
    public class LoanHistory
    {
        public int Id { get; set; }

        [Required] public BookDetails BookDetails { get; set; }

        [Required] public Member Member { get; set; }

        [Required] public DateTime LoanedOut { get; set; }

        public DateTime? Returned { get; set; }
    }
}
