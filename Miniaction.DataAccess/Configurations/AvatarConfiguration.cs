using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class AvatarConfiguration : FileConfiguration<Avatar>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Avatar> builder)
        {
            base.ConfigureEntity(builder);
            builder.HasIndex(x => x.UserID)
                .IsUnique();
            builder.HasOne(x => x.User)
                .WithOne(x => x.Avatar)
                .HasForeignKey<Avatar>(x => x.UserID)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }

}
