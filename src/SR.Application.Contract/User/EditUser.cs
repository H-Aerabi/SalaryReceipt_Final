using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application.Contract.User
{
    public class EditUser
    {
        public int Id { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Resources.User))]
        public string Code { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(Resources.User))]
        // [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.User))]
        //[Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress,ErrorMessage ="فرمت {0} درست نیس")]
        [EmailAddress(ErrorMessage = "فرمت {0} درست نیست")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.User))]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "فرمت {0} اشتباه است")]
        //[Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Organization", ResourceType = typeof(Resources.User))]
        public string Organization { get; set; }


    }
}
