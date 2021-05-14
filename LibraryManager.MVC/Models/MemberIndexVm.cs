using LibraryManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.MVC.Models
{
    public class MemberIndexVm
    {
        public IEnumerable<Member> Members { get; set; } = new List<Member>();
    }
}
