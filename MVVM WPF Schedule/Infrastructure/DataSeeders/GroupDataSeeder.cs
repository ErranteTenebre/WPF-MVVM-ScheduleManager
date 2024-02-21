using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class GroupDataSeeder : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> modelBuilder)
    {
        modelBuilder.HasData(
            new Group() {Number="20И1", IsBudget=true, AdmissionYear=2020, SpecialtyCode="09.02.04"},
            new Group() {Number = "20И2", IsBudget = false, AdmissionYear = 2020, SpecialtyCode = "09.02.04" },
            new Group() {Number = "20КС1", IsBudget = true, AdmissionYear = 2020, SpecialtyCode = "09.02.02" },
            new Group() {Number = "20КС2", IsBudget = false, AdmissionYear = 2020, SpecialtyCode = "09.02.02" }
        );
    }
}