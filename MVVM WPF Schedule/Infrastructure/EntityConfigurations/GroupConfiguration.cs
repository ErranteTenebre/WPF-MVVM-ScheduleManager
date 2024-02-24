using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(e => e.Number);

        builder.Property(p => p.SpecialtyCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.IsBudget)
            .IsRequired();

        builder.Property(e => e.AdmissionYear)
            .IsRequired();

        builder.HasOne(g => g.Specialty)
            .WithMany()
            .HasForeignKey(g => g.SpecialtyCode);
    }
}