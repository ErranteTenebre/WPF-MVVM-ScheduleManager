using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
