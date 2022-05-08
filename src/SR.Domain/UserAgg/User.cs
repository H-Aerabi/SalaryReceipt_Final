
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Domain.JournalAgg;
using SR.Domain.OrganizationAgg;
namespace SR.Domain.UserAgg
{
    public class User
    {


        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string NationalCode { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string ActiceCode { get; set; }

        //navigation properties

        public Organization Organization { get; set; }
        public List<Journal> Journals { get; set; }

        public User()
        {

        }

        public User(string nationalCode, int organizationId, string password, bool isAdmin = false, string fullName = null, string email = null, string phoneNumber = null)
        {
            NationalCode = nationalCode;
            OrganizationId = organizationId;
            FullName = fullName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = true;
            IsRemoved = false;
            IsAdmin = isAdmin;
        }

        public void Edit(bool isAdmin, int organizationId, string fullName = null, string email = null, string phoneNumber = null)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            IsAdmin = isAdmin;
            OrganizationId = organizationId;
        }
        public void Edit(string fullName=null,string email=null,string phoneNumber = null)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;

        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
        public void Remove()
        {
            IsRemoved = true;

        }
        public void Restor()
        {
            IsRemoved = true;

        }

        public void Active()
        {
            IsActive = true;
        }
        public void DisActive()
        {
            IsActive = false;
        }
    }



}
