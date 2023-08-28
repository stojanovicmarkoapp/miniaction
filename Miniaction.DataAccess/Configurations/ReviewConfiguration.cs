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
    public class ReviewConfiguration : EntityConfiguration<Review>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.ModifiedAt)
                .IsRequired();
            builder.Property(x => x.Comment)
                .IsRequired();
            builder.HasAlternateKey(x =>
                new
                {
                    x.OptionID,
                    x.UserID
                });
        }
    }
}
