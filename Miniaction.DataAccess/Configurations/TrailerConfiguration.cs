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
    public class TrailerConfiguration : FileConfiguration<Trailer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Trailer> builder)
        {
            base.ConfigureEntity(builder);
            builder.HasIndex(x => x.SerialID)
                .IsUnique();
            builder.HasOne(x => x.Serial)
                .WithOne(x => x.Trailer)
                .HasForeignKey<Trailer>(x => x.SerialID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
