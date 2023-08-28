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
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderedAt)
                .IsRequired();
            builder.Property(x => x.Paid)
                .IsRequired();
            builder.Property(x => x.Quantity)
                .IsRequired();
            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
