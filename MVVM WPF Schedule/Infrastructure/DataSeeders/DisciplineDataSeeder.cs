using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class DisciplineDataSeeder : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasData(
            new Discipline()
            {
                Id = 1,
                Name = "Информационные технологии и платформы разработки информационных систем (ч.1)",
            },
            new Discipline()
            {
                Id = 2,
                Name = "Физическая культура",
            },
            new Discipline()
            {
                Id = 3,
                Name = "Иностранный язык",
            },
            new Discipline()
            {
                Id = 4,
                Name = "Информационные системы в организации авиационного производства",
            },
            new Discipline()
            {
                Id = 5,
                Name = "Инновационное предпринимательство",
            },
            new Discipline()
            {
                Id = 6,
                Name = "Безопасность функционирования информационных систем",
            },
            new Discipline()
            {
                Id = 7,
                Name = "Организация администрирования компьютерных систем",
            },
            new Discipline()
            {
                Id = 8,
                Name = "Эксплуатация объектов сетевой инфраструктуры (ч.1)",
            },
            new Discipline()
            {
                Id = 9,
                Name = "Эксплуатация объектов сетевой инфраструктуры (ч.2)",
            },
            new Discipline()
            {
                Id = 10,
                Name = "Информационные технологии и платформы разработки информационных систем (ч.2)",
            }


        );
    }
}