using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class UserDataSeeder : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder.HasData(
            new User
            {
                Id = 1,
                FIO = "Иванов Иван Иванович",
                Phone = "+79123456789",
                Email = "ivanov@example.com",
                Password = "password123",
                Login = "ivanov",
                AvatarPath = "чебупеля.jpg",
                PostId = 1
            },
            new User
            {
                Id = 2,
                FIO = "Петров Петр Петрович",
                Phone = "+79234567890",
                Email = "petrov@example.com",
                Password = "password456",
                Login = "petrov",
                AvatarPath = "чебупеля.jpg",
                PostId = 2
            }
        );
    }
}