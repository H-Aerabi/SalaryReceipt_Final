using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Domain.UserAgg;

namespace SR.Domain.OrganizationAgg
{
  public  class Organization
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }
        public string Website { get; set; }

        //navigation property
        public List<User> Users { get; set; }

        public Organization(string name,string code,string address, string phoneNumber, string website=null)
        {
            Name = name;
            Code = code;
            Address = address;
            PhoneNumber = phoneNumber;
            Website = website;
        }

        public Organization()
        {
        }

        public void Edit(string code ,string name,string address,string phoneNumber,string website = null)
        {
            Name = name;
            Address = address;
            PhoneNumber=phoneNumber;
            Website = website;
            Code = code;
        }
    }


}
