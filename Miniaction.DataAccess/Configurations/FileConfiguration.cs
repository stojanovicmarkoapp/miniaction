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
    public abstract class FileConfiguration<T> : EntityConfiguration<T>
        where T : File
    {
        protected override void ConfigureEntity(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
