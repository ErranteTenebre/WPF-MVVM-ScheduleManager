using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations
{
    public class ScheduleItemConfiguration : IEntityTypeConfiguration<ScheduleItem>
    {
        public void Configure(EntityTypeBuilder<ScheduleItem> builder)
        {
            builder.HasOne(r => r.DayOfWeekDay)
                .WithMany()
                .HasForeignKey(r => r.DayOfWeekId);

            builder.HasOne(r => r.GroupDiscipline)
                .WithMany()
                .HasForeignKey(r => r.GroupDisciplineId);
        }
    }
}
