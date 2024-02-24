using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVVM_WPF_Schedule.Models.Entities;

namespace MVVM_WPF_Schedule.Infrastructure.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.FIO)
            .IsRequired()
            .HasMaxLength(70);

        builder.Property(e => e.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Login)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.AvatarName)
            .HasMaxLength(40);

        builder.HasOne(u => u.Post)
            .WithMany()
            .HasForeignKey(u => u.PostId);

        builder.HasIndex(e => e.FIO)
            .IsUnique();

        builder.HasIndex(e => e.Phone)
            .IsUnique();

        builder.HasIndex(e => e.Login)
            .IsUnique();
    }
}