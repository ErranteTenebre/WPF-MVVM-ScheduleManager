using System.IO;
using System.Security.Principal;
using System.Windows.Controls;
using System.Windows.Input;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.Services;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Pages;
using MVVM_WPF_Schedule.Views.Pages.Secretary;
using MVVM_WPF_Schedule.Views.Windows;

namespace MVVM_WPF_Schedule.ViewModels.Windows;

public class SecretaryViewModel : ViewModelBase
{
    private IUserRepository _userRepository;
    private SecretaryNavigationService _secretaryNavigationService;

    private CurrentUser _currentUser;

    public CurrentUser CurrentUser
    {
        get
        {
            return _currentUser;
        }
        set
        {
            _currentUser = value;
            OnPropertyChanged();
            OnPropertyChanged();
        }
    }
   
    public ICommand ShowHomeViewCommand { get; }
    public ICommand ShowSpecialtiesViewModel { get; }
    public ICommand ShowGroupsViewModel { get; }
    public ICommand ShowTeachersViewModel { get; }
    public ICommand ShowDisciplinesViewModel { get; }
    public ICommand LogOutCommand { get; }

    public SecretaryNavigationService SecretaryNavigationService
    {
        get => _secretaryNavigationService;
        set
        {
            if (Equals(value, _secretaryNavigationService)) return;
            _secretaryNavigationService = value;
            OnPropertyChanged();
        }
    }

    public event EventHandler OnDestroy;
        public SecretaryViewModel(IUserRepository userRepository, SecretaryNavigationService secretaryNavigationService)
        {
            ShowSpecialtiesViewModel = new ViewModelCommand(ExecuteShowSpecialtiesViewModel);
            ShowGroupsViewModel = new ViewModelCommand(ExecuteShowGroupsViewModel);
            ShowTeachersViewModel = new ViewModelCommand(ExecuteShowTeachersViewModel);
            ShowDisciplinesViewModel = new ViewModelCommand(ExecuteShowDisciplineViewModel);

            LogOutCommand = new ViewModelCommand(ExecuteLogOutCommand);

            _userRepository = userRepository;
            SecretaryNavigationService = secretaryNavigationService;
            SecretaryNavigationService.ChangeCurrentChildView(new SpecialtiesView(), "Специальности", IconChar.UserGraduate);

        LoadCurrentUserData();
        }

    private void ExecuteShowDisciplineViewModel(object obj)
    {
        SecretaryNavigationService.ChangeCurrentChildView(new DisciplinesView(), "Дисциплины", IconChar.Book);
    }

    private void ExecuteLogOutCommand(object obj)
    {
        Thread.CurrentPrincipal = null;

        MainWindow mainWindow = new MainWindow();

        mainWindow.Show();

        OnDestroy.Invoke(this, new EventArgs());
    }

    private void ExecuteShowSpecialtiesViewModel(object obj)
    {
        SecretaryNavigationService.ChangeCurrentChildView(new SpecialtiesView(), "Специальности",
            IconChar.UserGraduate);
    }

    private void ExecuteShowGroupsViewModel(object obj)
    {
        SecretaryNavigationService.ChangeCurrentChildView(new GroupsView(), "Группы",
            IconChar.Users);
    }

    private void ExecuteShowTeachersViewModel(object obj)
    {
        SecretaryNavigationService.ChangeCurrentChildView(new TeachersView(), "Преподаватели",
            IconChar.UserTie);
    }

    private void LoadCurrentUserData()
    {
        IPrincipal principals = Thread.CurrentPrincipal;

        if (principals == null) return;

        string username = principals.Identity.Name;

        User user = _userRepository.GetByUsername(username);

        if (user == null) return;

        CurrentUser = new CurrentUser()
        {
            Id = user.Id,
            FIO = user.FIO,
        };

        if (user.AvatarName != null)
        {
            byte[] avatar = File.ReadAllBytes(App.CurrentDirectory + "/Images/Avatars/" + user.AvatarName);
            CurrentUser.Avatar = avatar;
        }
    }
}