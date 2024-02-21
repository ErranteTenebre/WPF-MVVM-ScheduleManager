using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class SpecialtyDisciplinesSeeder : IEntityTypeConfiguration<SpecialtyDiscipline>
{
    public void Configure(EntityTypeBuilder<SpecialtyDiscipline> builder)
    {
        builder.HasData(
            new SpecialtyDiscipline()
            {
                Id = 1,
                SpecialtyCode = "09.02.04",
                DisciplineId = 1,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 2,
                SpecialtyCode = "09.02.04",
                DisciplineId = 2,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 3,
                SpecialtyCode = "09.02.04",
                DisciplineId = 3,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 4,
                SpecialtyCode = "09.02.04",
                DisciplineId = 4,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 5,
                SpecialtyCode = "09.02.02",
                DisciplineId = 5,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 6,
                SpecialtyCode = "09.02.02",
                DisciplineId = 6,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 7,
                SpecialtyCode = "09.02.02",
                DisciplineId = 7,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 8,
                SpecialtyCode = "09.02.02",
                DisciplineId = 8,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 9,
                SpecialtyCode = "09.02.02",
                DisciplineId = 2,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 10,
                SpecialtyCode = "09.02.02",
                DisciplineId = 3,
                HoursCountPerWeek = 400
            }, new SpecialtyDiscipline()
            {
                Id = 11,
                SpecialtyCode = "09.02.04",
                DisciplineId = 10,
                HoursCountPerWeek = 400
            },
            new SpecialtyDiscipline()
            {
                Id = 12,
                SpecialtyCode = "09.02.02",
                DisciplineId = 9,
                HoursCountPerWeek = 400
            }
        );
    }
}