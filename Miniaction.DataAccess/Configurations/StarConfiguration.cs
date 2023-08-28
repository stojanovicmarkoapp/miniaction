using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class StarConfiguration : EntityConfiguration<Star>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Star> builder)
        {
            builder.Property(x => x.Score)
                .IsRequired();
            builder.HasIndex(x => x.Score)
                .IsUnique();
            builder.Property(x => x.Description)
                .IsRequired();
            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Star)
                .HasForeignKey(x => x.StarID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
