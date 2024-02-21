using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class TeacherDataSeeder : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> modelBuilder)
    {
        modelBuilder.HasData(
            new Teacher
            {
                Id = 1,
                FIO = "Андреева Татьяна Эдуардовна",
                Phone = "+7(923)456-78-90",
                Workload = 432
            },
            new Teacher
            {
                Id = 2,
                FIO = "Трифонова Элина Марсовна",
                Phone = "+7(998)765-43-21",
                Workload = 450
            },
            new Teacher
            {
                Id = 3,
                FIO = "Нургалиева Альбина Шамсулловна",
                Phone = "+7(955)555-55-55",
                Workload = 420
            },
            new Teacher
            {
                Id = 4,
                FIO = "Рязанов Евгений Владимирович",
                Phone = "+7(966)666-66-66",
                Workload = 420
            },
            new Teacher
            {
                Id = 5,
                FIO = "Цыбина Евгений Александровна",
                Phone = "+7(977)777-77-77",
                Workload = 370
            },
            new Teacher
            {
                Id = 6,
                FIO = "Латыпова Лилия Азгамовна",
                Phone = "+7(955)222-31-81",
                Workload = 422
            },
            new Teacher
            {
                Id = 7,
                FIO = "Айметдинова Ульяна Александровна",
                Phone = "+7(914)351-44-51",
                Workload = 360
            },
            new Teacher
            {
                Id = 8,
                FIO = "Сайтуколова Ольга Ремовна",
                Phone = "+7(971)581-24-35",
                Workload = 400
            },
            new Teacher
            {
                Id = 9,
                FIO = "Челяева Ирина Валерьевна",
                Phone = "+7(911)84-88-55",
                Workload = 360
            },
            new Teacher
            {
                Id = 10,
                FIO = "Мавлекеева Лилия Эльдаровна",
                Phone = "+7(982)84-73-12",
                Workload = 380
            },
            new Teacher
            {
                Id = 11,
                FIO = "Cафиуллина Лейсан Маратовна",
                Phone = "+7(951)55-26-71",
                Workload = 340
            }
        );
    }
}