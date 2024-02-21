using Microsoft.Extensions.DependencyInjection;
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

namespace MVVM_WPF_Schedule.ViewModels.Base;

public class ViewModelLocator
{
    public static MainViewModel MainViewModel => App.Host.Services.GetRequiredService<MainViewModel>();
    public static LoginViewModel LogInViewModel => App.Host.Services.GetRequiredService<LoginViewModel>();

    public static SecretaryViewModel SecretaryViewModel => App.Host.Services.GetRequiredService<SecretaryViewModel>();
    public static DispatcherViewModel DispatcherViewModel => App.Host.Services.GetRequiredService<DispatcherViewModel>();
    public static ScheduleStudentViewModel ScheduleStudentViewModel => App.Host.Services.GetRequiredService<ScheduleStudentViewModel>();

    public static ScheduleTeacherViewModel ScheduleTeacherViewModel => App.Host.Services.GetRequiredService<ScheduleTeacherViewModel>();


    public static HomeViewModel HomeViewModel => App.Host.Services.GetRequiredService<HomeViewModel>();

    public static SpecialtiesViewModel SpecialtiesViewModel => App.Host.Services.GetRequiredService<SpecialtiesViewModel>();

    public static GroupsViewModel GroupsViewModel => App.Host.Services.GetRequiredService<GroupsViewModel>();

    public static TeachersViewModel TeachersViewModel => App.Host.Services.GetRequiredService<TeachersViewModel>();

    public static DisciplinesViewModel DisciplinesViewModel => App.Host.Services.GetRequiredService<DisciplinesViewModel>();

    public static SpecialtyDisciplinesViewModel SpecialtyDisciplinesViewModel => App.Host.Services.GetRequiredService<SpecialtyDisciplinesViewModel>();

    public static GroupDisciplinesViewModel GroupDisciplinesViewModel => App.Host.Services.GetRequiredService<GroupDisciplinesViewModel>();

    public static ScheduleViewModel ScheduleViewModel => App.Host.Services.GetRequiredService<ScheduleViewModel>();
 

    public static AddSpecialtyViewModel AddSpecialtyViewModel => App.Host.Services.GetRequiredService<AddSpecialtyViewModel>();

    public static EditSpecialtyViewModel EditSpecialtyViewModel => App.Host.Services.GetRequiredService<EditSpecialtyViewModel>();

    public static AddGroupViewModel AddGroupViewModel => App.Host.Services.GetRequiredService<AddGroupViewModel>();

    public static EditGroupViewModel EditGroupViewModel => App.Host.Services.GetRequiredService<EditGroupViewModel>();

    public static AddTeacherViewModel AddTeacherViewModel => App.Host.Services.GetRequiredService<AddTeacherViewModel>();

    public static EditTeacherViewModel EditTeacherViewModel => App.Host.Services.GetRequiredService<EditTeacherViewModel>();

    public static AddDisciplineViewModel AddDisciplineViewModel => App.Host.Services.GetRequiredService<AddDisciplineViewModel>();

    public static EditDisciplineViewModel EditDisciplineViewModel => App.Host.Services.GetRequiredService<EditDisciplineViewModel>();

    public static AddSpecialtyDisciplineViewModel AddSpecialtyDisciplineViewModel => App.Host.Services.GetRequiredService<AddSpecialtyDisciplineViewModel>();

    public static EditSpecialtyDisciplineViewModel EditSpecialtyDisciplineViewModel =>
        App.Host.Services.GetRequiredService<EditSpecialtyDisciplineViewModel>();
}