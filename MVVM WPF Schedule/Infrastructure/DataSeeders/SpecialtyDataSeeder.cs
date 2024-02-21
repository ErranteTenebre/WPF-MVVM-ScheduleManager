using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class SpecialtyDataSeeder : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> modelBuilder)
    {
            modelBuilder.HasData(
                new Specialty() { Code = "09.02.04", Name = "Информационные системы", Acronym="И"},
                new Specialty() { Code = "09.02.02", Name = "Компьютерные сети", Acronym="КС"}
            );
        }
}