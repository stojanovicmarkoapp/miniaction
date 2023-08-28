using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class FormatConfiguration : EntityConfiguration<Format>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Format> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.HasMany(x => x.Options)
                .WithOne(x => x.Format)
                .HasForeignKey(x => x.FormatID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
