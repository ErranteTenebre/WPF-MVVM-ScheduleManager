using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations
{
    public class ScheduleItemConfiguration : IEntityTypeConfiguration<ScheduleItem>
    {
        public void Configure(EntityTypeBuilder<ScheduleItem> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.GroupDisciplineId)
                .IsRequired();

            builder.Property(e => e.LessonNumber)
                .IsRequired();

            builder.Property(e => e.DayOfWeekId)
                .IsRequired();

            builder.HasOne(r => r.DayOfWeekDay)
                .WithMany()
                .HasForeignKey(r => r.DayOfWeekId);

            builder.HasOne(r => r.GroupDiscipline)
                .WithMany()
                .HasForeignKey(r => r.GroupDisciplineId);

            builder.HasCheckConstraint("CHK_Check_Lesson_Number", "LessonNumber>0 AND LessonNumber<=8");
        }
    }
}
