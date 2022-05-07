using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Application.Contract.Organization
{
    public class CreateOrganization
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Organization))]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(50,ErrorMessage ="{0} نمی تواند بیش از {1} باشد")]
        public string Name { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Resources.Organization))]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(14,ErrorMessage ="{0} نمی تواند بیش از {1} باشد")]
        public string Code { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Organization))]
        [RegularExpression(@"^(\+98|0)?9\d{9}$",ErrorMessage ="فرمت {0} اشتباه است")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.Organization))]
        [MaxLength(500,ErrorMessage ="{0} نمی تواند بیش از {1} باشد")]
        public string Address { get; set; }

        [Display(Name = "Website", ResourceType = typeof(Resources.Organization))]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیش از {1} باشد")]
        public string Website { get; set; }

    }
}
