using SR.Domain.JournalAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Infrastructure.EF.Mappings
{
    public class JournalMapping: EntityTypeConfiguration<Journal>
    {
        public JournalMapping()
        {
            this.ToTable("Journals");
            this.HasKey(j => j.Id);
            //this.Property(j => j.AcountNumber).IsRequired();
            //this.Property(j => j.RullNumber).IsRequired();
            //this.Property(j => j.CollaborationType).IsRequired();

            this.Property(j => j.AcountNumber).HasMaxLength(30);
            this.Property(j => j.RullNumber).HasMaxLength(50);
            this.Property(j => j.CollaborationType).HasMaxLength(100);

            //Relation with User
            this.HasRequired(j => j.User)
                .WithMany(u => u.Journals)
                .HasForeignKey(j => j.UserId);

            //Relation with Posting
            this.HasMany(j => j.Postings)
                .WithRequired(p => p.Journal)
                .HasForeignKey(p => p.JournalId);
            
        }

    }
}
