﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MVVM_WPF_Schedule.Infrastructure.DataSeeders;
using MVVM_WPF_Schedule.Infrastructure.EntityConfigurations;
using MVVM_WPF_Schedule.Models.Entities;
using System.IO;
using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.Infrastructure;

public class AppDbContext : DbContext
{       
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<SpecialtyDiscipline> SpecialtiesDisciplines{get;set;}
    public DbSet<GroupDiscipline> GroupsDisciplines {get; set; }
    public DbSet<DayOfWeek> DaysOfWeek { get; set; }
    public DbSet<ScheduleItem> ScheduleItems { get; set; }
    public AppDbContext(DbContextOptions options) :base(options) {     
    }                                   
                                            
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new SpecialtyDisciplinesConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new GroupDisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleItemConfiguration());

        modelBuilder.ApplyConfiguration(new SpecialtyDataSeeder());
        modelBuilder.ApplyConfiguration(new GroupDataSeeder());
        modelBuilder.ApplyConfiguration(new PostDataSeeder());
        modelBuilder.ApplyConfiguration(new UserDataSeeder());
        modelBuilder.ApplyConfiguration(new TeacherDataSeeder());
        modelBuilder.ApplyConfiguration(new DisciplineDataSeeder());
        modelBuilder.ApplyConfiguration(new SpecialtyDisciplinesSeeder());
        modelBuilder.ApplyConfiguration(new GroupDisciplineDataSeeder());
        modelBuilder.ApplyConfiguration(new DayOfWeekDataSeeder());
        modelBuilder.ApplyConfiguration(new ScheduleItemDataSeeder());

        base.OnModelCreating(modelBuilder);
    }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        optionsBuilder.EnableSensitiveDataLogging();

        return new AppDbContext(optionsBuilder.Options);
    }
}