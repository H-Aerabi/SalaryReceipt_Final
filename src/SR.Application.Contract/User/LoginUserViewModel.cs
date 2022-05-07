using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SR.Application.Contract.User
{
    public class LoginUser
    {
        [Display(Name = "UserName", ResourceType = typeof(Resources.User))]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "فرمت {0} ملی اشتباه است ")]
        public string Code { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.User))]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [Display(Name = "Organization", ResourceType = typeof(Resources.User))]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        public int OrganizationId { get; set; }


    }
}
