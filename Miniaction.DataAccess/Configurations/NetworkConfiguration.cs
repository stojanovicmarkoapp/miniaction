using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class NetworkConfiguration : EntityConfiguration<Network>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Network> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.HasMany(x => x.Serials)
                .WithOne(x => x.Network)
                .HasForeignKey(x => x.NetworkID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
