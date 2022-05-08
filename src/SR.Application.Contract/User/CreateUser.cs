using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Application.Contract.Resources;

namespace SR.Application.Contract.User
{
    public class CreateUser
    {
        [Display(Name = "UserName", ResourceType = typeof(Resources.User))]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
       [RegularExpression(@"^[0-9]{10}$", ErrorMessage ="فرمت  {0} اشتباه است ")]
        ///^[0-9]{10}$/g
        public string Code { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(Resources.User))]
        // [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.User))]
        //[Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "فرمت {0} درست نیست")]
        [DataType(DataType.EmailAddress,ErrorMessage ="فرمت {0} درست نیس")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.User))]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "فرمت {0} اشتباه است")]
        //[Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "Organization", ResourceType = typeof(Resources.User))]
       public int OrganizationId { get; set; }

        [Display(Name = "IsAdmin", ResourceType = typeof(Resources.User))]
        public bool IsAdmin { get; set; }


    }
}
