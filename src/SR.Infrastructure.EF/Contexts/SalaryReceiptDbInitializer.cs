using SR.Domain.OrganizationAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Domain.UserAgg;

namespace SR.Infrastructure.EF.Contexts
{
    public class SalaryReceiptDBInitializer<T> : CreateDatabaseIfNotExists<SalaryReceiptContext>
    {
        protected override void Seed(SalaryReceiptContext context)
        {
            List<Organization> organizations = new List<Organization>();
            List<User> users = new List<User>();


            organizations.Add(new Organization() { Id=1,Code="123",Name="سازمان 1" });
            users.Add(new User() { Id = 1,OrganizationId=1, Code = "4680210311", FullName = "Admin", Password = "Admin123",IsAdmin=true,IsActive=true,IsRemoved=false});
          

            context.Organizations.AddRange(organizations);
            context.Users.AddRange(users);
            base.Seed(context);
        }

    }
}
