using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasOne(g=> g.Specialty)
            .WithMany()
            .HasForeignKey(g => g.SpecialtyCode);

        builder.HasMany(group => group.GroupDisciplines)
            .WithOne(groupDiscipline => groupDiscipline.Group)
            .HasForeignKey(groupDiscipline => groupDiscipline.GroupNumber)
            .OnDelete(DeleteBehavior.Cascade);
    }
}