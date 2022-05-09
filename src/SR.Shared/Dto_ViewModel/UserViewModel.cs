using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Shared.Dto_ViewModel
{
   public class UserViewModel
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public string Organization { get; set; }
    }
}
