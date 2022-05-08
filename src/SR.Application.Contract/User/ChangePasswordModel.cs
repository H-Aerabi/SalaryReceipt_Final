using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application.Contract.User
{
    public class ChangePasswordModel
    {
        [Display(Name = "CurrentPassword", ResourceType = typeof(Resources.User))]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.User))]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "RePassword", ResourceType = typeof(Resources.User))]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("Password",ErrorMessage ="{0} با {1} مطابقت ندارد")]
        public string RePassword { get; set; }

    }
}
