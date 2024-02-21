using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;
using Entities_DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class DayOfWeekDataSeeder : IEntityTypeConfiguration<Entities_DayOfWeek>
{
    public void Configure(EntityTypeBuilder<DayOfWeek> builder)
    {
        builder.HasData(
            new DayOfWeek()
            {
                Id = 1,
                Name = "Понедельник"
            },
            new DayOfWeek()
            {
                Id = 2,
                Name = "Вторник"
            },
            new DayOfWeek()
            {
                Id = 3,
                Name = "Среда"
            },
            new DayOfWeek()
            {
                Id = 4,
                Name = "Четверг"
            },
            new DayOfWeek()
            {
                Id = 5,
                Name = "Пятница"
            },
            new DayOfWeek()
            {
                Id = 6,
                Name = "Суббота"
            }
        );
    }
}