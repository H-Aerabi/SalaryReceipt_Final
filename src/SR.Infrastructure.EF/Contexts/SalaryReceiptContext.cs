using SR.Domain.JournalAgg;
using SR.Domain.OrganizationAgg;
using SR.Domain.PostingAgg;
using SR.Domain.UserAgg;
using SR.Infrastructure.EF.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Hierarchy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Infrastructure.EF.Contexts
{

    public class SalaryReceiptContext:DbContext
    {
        
        public SalaryReceiptContext():base("SRConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }
 
        public DbSet<Organization> Organizations { get;set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Posting> Postings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //add mappings
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new OrganizationMapping());
            modelBuilder.Configurations.Add(new JournalMapping());
            modelBuilder.Configurations.Add(new PostingMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
