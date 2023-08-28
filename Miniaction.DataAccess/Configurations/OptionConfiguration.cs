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
    public class OptionConfiguration : EntityConfiguration<Option>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Option> builder)
        {
            builder.Property(x => x.Available)
                .HasDefaultValue(true);
            builder.Property(x => x.Price)
                .IsRequired();
            builder.HasAlternateKey(x =>
                new
                {
                    x.SerialID,
                    x.FormatID
                });
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Option)
                .HasForeignKey(x => x.OptionID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Option)
                .HasForeignKey(x => x.OptionID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
