using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class ScheduleItemDataSeeder : IEntityTypeConfiguration<ScheduleItem>
{
    public void Configure(EntityTypeBuilder<ScheduleItem> builder)
    {
        builder.HasData(
            new ScheduleItem { Id = 1, GroupDisciplineId = 8, LessonNumber = 4, DayOfWeekId = 1 },
            new ScheduleItem { Id = 2, GroupDisciplineId = 6, LessonNumber = 5, DayOfWeekId = 1 },
            new ScheduleItem { Id = 3, GroupDisciplineId = 18, LessonNumber = 2, DayOfWeekId = 2 },
            new ScheduleItem { Id = 4, GroupDisciplineId = 18, LessonNumber = 3, DayOfWeekId = 2 },
            new ScheduleItem { Id = 5, GroupDisciplineId = 8, LessonNumber = 4, DayOfWeekId = 2 },
            new ScheduleItem { Id = 6, GroupDisciplineId = 8, LessonNumber = 1, DayOfWeekId = 3 },
            new ScheduleItem { Id = 7, GroupDisciplineId = 5, LessonNumber = 2, DayOfWeekId = 3 },
            new ScheduleItem { Id = 8, GroupDisciplineId = 18, LessonNumber = 3, DayOfWeekId = 3 },
            new ScheduleItem { Id = 10, GroupDisciplineId = 5, LessonNumber = 4, DayOfWeekId = 4 },
            new ScheduleItem { Id = 11, GroupDisciplineId = 18, LessonNumber = 5, DayOfWeekId = 4 },
            new ScheduleItem { Id = 12, GroupDisciplineId = 6, LessonNumber = 6, DayOfWeekId = 4 },
            new ScheduleItem { Id = 13, GroupDisciplineId = 5, LessonNumber = 1, DayOfWeekId = 6 },
            new ScheduleItem { Id = 14, GroupDisciplineId = 18, LessonNumber = 2, DayOfWeekId = 6 },
            new ScheduleItem { Id = 15, GroupDisciplineId = 18, LessonNumber = 3, DayOfWeekId = 6 },
            new ScheduleItem { Id = 16, GroupDisciplineId = 18, LessonNumber = 4, DayOfWeekId = 6 },
            new ScheduleItem { Id = 19, GroupDisciplineId = 9, LessonNumber = 3, DayOfWeekId = 1 },
            new ScheduleItem { Id = 20, GroupDisciplineId = 9, LessonNumber = 4, DayOfWeekId = 1 },
            new ScheduleItem { Id = 21, GroupDisciplineId = 9, LessonNumber = 5, DayOfWeekId = 1 },
            new ScheduleItem { Id = 23, GroupDisciplineId = 10, LessonNumber = 4, DayOfWeekId = 3 },
            new ScheduleItem { Id = 24, GroupDisciplineId = 19, LessonNumber = 5, DayOfWeekId = 3 },
            new ScheduleItem { Id = 25, GroupDisciplineId = 11, LessonNumber = 6, DayOfWeekId = 3 },
            new ScheduleItem { Id = 26, GroupDisciplineId = 12, LessonNumber = 3, DayOfWeekId = 4 },
            new ScheduleItem { Id = 27, GroupDisciplineId = 11, LessonNumber = 4, DayOfWeekId = 4 },
            new ScheduleItem { Id = 28, GroupDisciplineId = 9, LessonNumber = 5, DayOfWeekId = 4 },
            new ScheduleItem { Id = 29, GroupDisciplineId = 9, LessonNumber = 6, DayOfWeekId = 4 },
            new ScheduleItem { Id = 30, GroupDisciplineId = 9, LessonNumber = 2, DayOfWeekId = 5 },
            new ScheduleItem { Id = 31, GroupDisciplineId = 9, LessonNumber = 3, DayOfWeekId = 5 },
            new ScheduleItem { Id = 32, GroupDisciplineId = 9, LessonNumber = 4, DayOfWeekId = 5 },
            new ScheduleItem { Id = 33, GroupDisciplineId = 9, LessonNumber = 5, DayOfWeekId = 5 },
            new ScheduleItem { Id = 34, GroupDisciplineId = 19, LessonNumber = 1, DayOfWeekId = 6 },
            new ScheduleItem { Id = 35, GroupDisciplineId = 19, LessonNumber = 2, DayOfWeekId = 6 },
            new ScheduleItem { Id = 36, GroupDisciplineId = 10, LessonNumber = 3, DayOfWeekId = 6 },
            new ScheduleItem { Id = 37, GroupDisciplineId = 10, LessonNumber = 4, DayOfWeekId = 6 },
            new ScheduleItem { Id = 40, GroupDisciplineId = 13, LessonNumber = 3, DayOfWeekId = 2 },
            new ScheduleItem { Id = 41, GroupDisciplineId = 13, LessonNumber = 4, DayOfWeekId = 2 },
            new ScheduleItem { Id = 42, GroupDisciplineId = 13, LessonNumber = 5, DayOfWeekId = 2 },
            new ScheduleItem { Id = 43, GroupDisciplineId = 20, LessonNumber = 1, DayOfWeekId = 3 },
            new ScheduleItem { Id = 44, GroupDisciplineId = 20, LessonNumber = 2, DayOfWeekId = 3 },
            new ScheduleItem { Id = 45, GroupDisciplineId = 16, LessonNumber = 3, DayOfWeekId = 3 },
            new ScheduleItem { Id = 47, GroupDisciplineId = 15, LessonNumber = 2, DayOfWeekId = 4 },
            new ScheduleItem { Id = 48, GroupDisciplineId = 13, LessonNumber = 3, DayOfWeekId = 4 },
            new ScheduleItem { Id = 49, GroupDisciplineId = 13, LessonNumber = 4, DayOfWeekId = 4 },
            new ScheduleItem { Id = 50, GroupDisciplineId = 15, LessonNumber = 5, DayOfWeekId = 4 },
            new ScheduleItem { Id = 52, GroupDisciplineId = 20, LessonNumber = 2, DayOfWeekId = 5 },
            new ScheduleItem { Id = 53, GroupDisciplineId = 20, LessonNumber = 3, DayOfWeekId = 5 },
            new ScheduleItem { Id = 54, GroupDisciplineId = 14, LessonNumber = 4, DayOfWeekId = 5 },
            new ScheduleItem { Id = 55, GroupDisciplineId = 14, LessonNumber = 5, DayOfWeekId = 5 },
            new ScheduleItem { Id = 56, GroupDisciplineId = 14, LessonNumber = 1, DayOfWeekId = 6 },
            new ScheduleItem { Id = 57, GroupDisciplineId = 14, LessonNumber = 2, DayOfWeekId = 6 },
            new ScheduleItem { Id = 58, GroupDisciplineId = 20, LessonNumber = 3, DayOfWeekId = 6 },
            new ScheduleItem { Id = 59, GroupDisciplineId = 20, LessonNumber = 4, DayOfWeekId = 6 },
            new ScheduleItem { Id = 60, GroupDisciplineId = 5, LessonNumber = 3, DayOfWeekId = 5 },
            new ScheduleItem { Id = 61, GroupDisciplineId = 5, LessonNumber = 4, DayOfWeekId = 5 },
            new ScheduleItem { Id = 62, GroupDisciplineId = 5, LessonNumber = 5, DayOfWeekId = 5 }
        );
    }
}