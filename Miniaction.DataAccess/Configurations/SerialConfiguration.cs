using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class SerialConfiguration : EntityConfiguration<Serial>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Serial> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();
            builder.HasIndex(x => x.Title);
            builder.Property(x => x.Features)
                .IsRequired();
            builder.Property(x => x.Released)
                .IsRequired();
            builder.HasIndex(x => x.TrailerID)
                .IsUnique()
                .HasFilter("[TrailerID] IS NOT NULL");
            builder.HasOne(x => x.Trailer)
                .WithOne(x => x.Serial)
                .HasForeignKey<Serial>(x => x.TrailerID)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.Options)
                .WithOne(x => x.Serial)
                .HasForeignKey(x => x.SerialID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
