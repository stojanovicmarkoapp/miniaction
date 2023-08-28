using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class PGConfiguration : EntityConfiguration<PG>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<PG> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.Property(x => x.Description)
                .IsRequired();
            builder.HasMany(x => x.Serials)
                .WithOne(x => x.PG)
                .HasForeignKey(x => x.PGID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
