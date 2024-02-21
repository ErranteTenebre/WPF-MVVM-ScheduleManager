using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders
{
    public class GroupDisciplineDataSeeder : IEntityTypeConfiguration<GroupDiscipline>
    {
        public void Configure(EntityTypeBuilder<GroupDiscipline> builder)
        {
            builder.HasData(
                new GroupDiscipline()
                {
                    Id = 1,
                    DisciplineId = 1,
                    GroupNumber = "20И1",
                    TeacherId = 2,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 2,
                    DisciplineId = 2,
                    GroupNumber = "20И1",
                    TeacherId = 4,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 3,
                    DisciplineId = 3,
                    GroupNumber = "20И1",
                    TeacherId = 1,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 4,
                    DisciplineId = 4,
                    GroupNumber = "20И1",
                    TeacherId = 3,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 5,
                    DisciplineId = 1,
                    GroupNumber = "20И2",
                    TeacherId = 3,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 6,
                    DisciplineId = 2,
                    GroupNumber = "20И2",
                    TeacherId = 4,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 7,
                    DisciplineId = 3,
                    GroupNumber = "20И2",
                    TeacherId = 1,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 8,
                    DisciplineId = 4,
                    GroupNumber = "20И2",
                    TeacherId = 3,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 9,
                    DisciplineId = 6,
                    GroupNumber = "20КС1",
                    TeacherId = 6,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 10,
                    DisciplineId = 8,
                    GroupNumber = "20КС1",
                    TeacherId = 10,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 11,
                    DisciplineId = 3,
                    GroupNumber = "20КС1",
                    TeacherId = 1,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 12,
                    DisciplineId = 2,
                    GroupNumber = "20КС1",
                    TeacherId = 4,
                    HoursCountPerWeek = 400,
                },
                 new GroupDiscipline()
                {
                    Id = 13,
                    DisciplineId = 6,
                    GroupNumber = "20КС2",
                    TeacherId = 6,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 14,
                    DisciplineId = 8,
                    GroupNumber = "20КС2",
                    TeacherId = 10,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 15,
                    DisciplineId = 3,
                    GroupNumber = "20КС2",
                    TeacherId = 1,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 16,
                    DisciplineId = 2,
                    GroupNumber = "20КС2",
                    TeacherId = 4,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 17,
                    DisciplineId = 10,
                    GroupNumber = "20И1",
                    TeacherId = 11,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 18,
                    DisciplineId = 10,
                    GroupNumber = "20И2",
                    TeacherId = 11,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 19,
                    DisciplineId = 9,
                    GroupNumber = "20КС1",
                    TeacherId = 8,
                    HoursCountPerWeek = 400,
                },
                new GroupDiscipline()
                {
                    Id = 20,
                    DisciplineId = 9,
                    GroupNumber = "20КС2",
                    TeacherId = 8,
                    HoursCountPerWeek = 400,
                }
                );
        }
    }
}
