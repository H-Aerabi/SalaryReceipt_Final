using SR.Domain.PostingAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Infrastructure.EF.Mappings
{
    public class PostingMapping: EntityTypeConfiguration<Posting>
    {

        public PostingMapping()
        {
            this.ToTable("Postings");
            this.HasKey(p => p.Id);
            //this.Property(p => p.Title).IsRequired();
            //this.Property(p => p.InstallmentNumber).IsRequired();

            this.Property(p => p.Title).HasMaxLength(100) ;
            this.Property(p => p.InstallmentNumber).HasMaxLength(50);

            //Relation with Journal
            this.HasRequired(p => p.Journal)
                .WithMany(j => j.Postings)
                .HasForeignKey(p => p.JournalId);
        }
    }
}
