using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application.Contract.User
{
    public class FullEditUser:EditUser
    {


        [Display(Name = "Organization", ResourceType = typeof(Resources.User))]
        public int OrganizationId { get; set; }

        [Display(Name = "IsAdmin", ResourceType = typeof(Resources.User))]
        public bool IsAdmin { get; set; }


    }
}
