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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FIO)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Workload)
                .IsRequired();

            builder.HasIndex(e => e.FIO)
                .IsUnique();

            builder.HasIndex(e => e.Phone)
                .IsUnique();

            builder.HasCheckConstraint("Workload_CHK", "Workload > 0 AND Workload <=36");

        }
    }
}
