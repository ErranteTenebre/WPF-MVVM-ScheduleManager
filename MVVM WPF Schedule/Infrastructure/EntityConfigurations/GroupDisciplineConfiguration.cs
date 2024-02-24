using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations
{
    public class GroupDisciplineConfiguration : IEntityTypeConfiguration<GroupDiscipline>
    {
        public void Configure(EntityTypeBuilder<GroupDiscipline> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DisciplineId)
                .IsRequired();
            builder.Property(e => e.TeacherId)
                .IsRequired();

            builder.Property(e => e.HoursCountPerWeek)
                .IsRequired();

            builder.HasOne(gd => gd.Group)
                .WithMany()
                .HasForeignKey(gd => gd.GroupNumber);
            builder.HasOne(gd => gd.Discipline)
                .WithMany()
                .HasForeignKey(gd => gd.DisciplineId);
            builder.HasOne(gd => gd.Teacher)
                .WithMany()
                .HasForeignKey(gd => gd.TeacherId);

            builder.HasCheckConstraint("CHK_Hours_Count_Per_Week", "HoursCountPerWeek>0");
        }
    }
}
