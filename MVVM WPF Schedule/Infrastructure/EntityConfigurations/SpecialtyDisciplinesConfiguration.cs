using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations;

public class SpecialtyDisciplinesConfiguration : IEntityTypeConfiguration<SpecialtyDiscipline>
{
    public void Configure(EntityTypeBuilder<SpecialtyDiscipline> builder)
    {
        builder.HasOne(sd => sd.Specialty)
            .WithMany()
            .HasForeignKey(sd=>sd.SpecialtyCode);
        builder.HasOne(sd => sd.Discipline)
            .WithMany()
            .HasForeignKey(sd => sd.DisciplineId);
    }
}