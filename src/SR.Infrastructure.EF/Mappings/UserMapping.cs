using SR.Domain.UserAgg;
using SR.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SR.Infrastructure.EF.Mappings
{
   public class UserMapping:EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("Users");
            this.HasKey(u => u.Id);
            this.Property(u => u.Code).HasMaxLength(10).IsRequired();
            //this.HasIndex(u => u.NationalCode).IsUnique();
            this.Property(u => u.FullName).HasMaxLength(50);
            this.Property(u => u.Password).HasMaxLength(500).IsRequired();
            this.Property(u => u.PhoneNumber).HasMaxLength(13);
           
            //Relation with Organization
            this.HasRequired(u => u.Organization)
               .WithMany(o => o.Users)
               .HasForeignKey(u => u.OrganizationId);

            //Relation with Journal
            this.HasMany(u => u.Journals)
              .WithRequired(j => j.User)
              .HasForeignKey(j => j.UserId);
        
        }
    }

}
