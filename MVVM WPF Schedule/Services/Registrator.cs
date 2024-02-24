using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVVM_WPF_Schedule.Infrastructure;
using MVVM_WPF_Schedule.Infrastructure.DataValidators;
using MVVM_WPF_Schedule.Infrastructure.Repositories.EntityFramework;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.ViewModels.Pages;
using MVVM_WPF_Schedule.ViewModels.Pages.Dispatcher;
using MVVM_WPF_Schedule.ViewModels.Pages.Main;
using MVVM_WPF_Schedule.ViewModels.Pages.Secretary;
using MVVM_WPF_Schedule.ViewModels.Popup.DisciplineViewModels;
using MVVM_WPF_Schedule.ViewModels.Popup.GroupViewModels;
using MVVM_WPF_Schedule.ViewModels.Popup.Specialty;
using MVVM_WPF_Schedule.ViewModels.Popup.SpecialtyDisciplineViewModels;
using MVVM_WPF_Schedule.ViewModels.Popup.TeacherViewModels;
using MVVM_WPF_Schedule.ViewModels.Windows;

namespace MVVM_WPF_Schedule.Services;

public static class Registrator
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies()
        .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.RegisterRepositories();
        services.RegisterDataValidators();
        services.RegisterViewModels();
        services.AddTransient<SecretaryNavigationService>();
        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<LoginViewModel>();
        services.AddTransient<SecretaryViewModel>();
        services.AddTransient<DispatcherViewModel>();
        services.AddTransient<MainViewModel>();

        services.AddTransient<ScheduleStudentViewModel>();
        services.AddTransient<ScheduleTeacherViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SpecialtiesViewModel>();
        services.AddTransient<GroupsViewModel>();
        services.AddTransient<TeachersViewModel>();
        services.AddTransient<DisciplinesViewModel>();
        services.AddTransient<SpecialtyDisciplinesViewModel>();
        services.AddTransient<GroupDisciplinesViewModel>();
        services.AddTransient<ScheduleViewModel>();

        services.AddTransient<AddSpecialtyViewModel>();
        services.AddTransient<EditSpecialtyViewModel>();

        services.AddTransient<AddGroupViewModel>();
        services.AddTransient<EditGroupViewModel>();

        services.AddTransient<AddTeacherViewModel>();
        services.AddTransient<EditTeacherViewModel>();

        services.AddTransient<AddDisciplineViewModel>();
        services.AddTransient<EditDisciplineViewModel>();

        services.AddTransient<AddSpecialtyDisciplineViewModel>();
        services.AddTransient<EditSpecialtyDisciplineViewModel>();

        return services;
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ISpecialtyRepository, SpecialtyRepository>();
        services.AddTransient<IGroupRepository, GroupRepository>();
        services.AddTransient<ITeacherRepository, TeacherRepository>();
        services.AddTransient<IDisciplineRepository, DisciplineRepository>();
        services.AddTransient<ISpecialtyDisciplinesRepository, SpecialtyDisciplinesRepository>();
        services.AddTransient<IGroupDisciplineRepository, GroupDisciplineRepository>();
        services.AddTransient<IScheduleItemRepository, ScheduleRepository>();
        services.AddTransient<IDayOfWeekRepository, DayOfWeekRepository>();

        return services;
    }

    private static IServiceCollection RegisterDataValidators(this IServiceCollection services)
    {
        services.AddTransient<GroupValidator>();
        services.AddTransient<TeacherValidator>();
        services.AddTransient<ScheduleDataValidator>();

        return services;
    }
}