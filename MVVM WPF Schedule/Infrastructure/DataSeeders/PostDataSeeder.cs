using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.DataSeeders;

public class PostDataSeeder : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> modelBuilder)
    {
        modelBuilder.HasData(
            new Post() {Id=1, Name="Секретарь"},
            new Post() {Id=2, Name="Диспетчер"}
        );
    }
}