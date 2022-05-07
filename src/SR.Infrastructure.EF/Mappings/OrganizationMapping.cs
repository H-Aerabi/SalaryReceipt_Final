using SR.Domain.OrganizationAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Infrastructure.EF.Mappings
{

    public class OrganizationMapping : EntityTypeConfiguration<Organization>
    {

        public OrganizationMapping()
        {
            this.ToTable("Organizations");
            this.HasKey(o => o.Id);
            this.HasIndex(o => o.Code).IsUnique();
            this.Property(o => o.Code).HasMaxLength(14).IsRequired();
            this.Property(o => o.Name).HasMaxLength(50).IsRequired();
            this.Property(o => o.Address).HasMaxLength(500);
            this.Property(o => o.Website).HasMaxLength(500);
            this.Property(o => o.PhoneNumber).HasMaxLength(13);
            this.Property(o => o.PhoneNumber);


            //relation with User
            this.HasMany(o => o.Users)
                .WithRequired(u => u.Organization)
                .HasForeignKey(u => u.OrganizationId);
        }
    }
}
