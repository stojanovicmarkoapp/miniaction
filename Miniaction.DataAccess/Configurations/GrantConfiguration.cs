using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess.Configurations
{
    public class GrantConfiguration : EntityConfiguration<Grant>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Grant> builder)
        {
            builder.HasAlternateKey(x =>
                new
                {
                    x.RoleID,
                    x.UseCaseID
                });
            builder.HasOne(x => x.Role)
                .WithMany(x => x.Grants)
                .HasForeignKey(x => x.RoleID)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
