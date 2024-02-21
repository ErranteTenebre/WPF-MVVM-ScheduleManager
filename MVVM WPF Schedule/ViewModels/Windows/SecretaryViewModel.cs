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
    private UserControl _currentChildView;
    private string _caption;
    private IconChar _icon;
    private bool isHomeViewChecked = false;
    private bool isSpecialtiesViewChecked = false;
    private bool isGroupsViewChecked = false;
    private bool isTeachersViewChecked = false;
    private bool isDisciplinesViewChecked = false;

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
    public UserControl CurrentChildView
    {
        get
        {
            return _currentChildView;
        }
        set
        {
            _currentChildView = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CurrentChildView));
        }
    }
    public string Caption
    {
        get
        {
            return _caption;
        }
        set
        {
            _caption = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Caption));
        }
    }
    public IconChar Icon
    {
        get
        {
            return _icon;
        }
        set
        {
            _icon = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Icon));
        }
    }

    public bool IsHomeViewChecked
    {
        get => isHomeViewChecked;
        set
        {
            if (value == isHomeViewChecked) return;
            isHomeViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsSpecialtiesViewChecked
    {
        get => isSpecialtiesViewChecked;
        set
        {
            if (value == isSpecialtiesViewChecked) return;
            isSpecialtiesViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsGroupsViewChecked
    {
        get => isGroupsViewChecked;
        set
        {
            if (value == isGroupsViewChecked) return;
            isGroupsViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsDisciplinesViewChecked
    {
        get => isDisciplinesViewChecked;
        set
        {
            if (value == isDisciplinesViewChecked) return;
            isDisciplinesViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsTeachersViewChecked
    {
        get => isTeachersViewChecked;
        set
        {
            if (value == isTeachersViewChecked) return;
            isTeachersViewChecked = value;
            OnPropertyChanged();
        }
    }

    //--> Commands
    public ICommand ShowHomeViewCommand { get; }
    public ICommand ShowSpecialtiesViewModel { get; }
    public ICommand ShowGroupsViewModel { get; }
    public ICommand ShowTeachersViewModel { get; }
    public ICommand ShowDisciplinesViewModel { get; }
    public ICommand LogOutCommand { get; }

    public event EventHandler OnDestroy;
        public SecretaryViewModel(IUserRepository userRepository, SecretaryNavigationService secretaryNavigationService)
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowSpecialtiesViewModel = new ViewModelCommand(ExecuteShowSpecialtiesViewModel);
            ShowGroupsViewModel = new ViewModelCommand(ExecuteShowGroupsViewModel);
            ShowTeachersViewModel = new ViewModelCommand(ExecuteShowTeachersViewModel);
            ShowDisciplinesViewModel = new ViewModelCommand(ExecuteShowDisciplineViewModel);

            LogOutCommand = new ViewModelCommand(ExecuteLogOutCommand);

            _userRepository = userRepository;
            _secretaryNavigationService = secretaryNavigationService;

            CurrentChildView = secretaryNavigationService.CurrentChildView;
        secretaryNavigationService.CurrentViewChanged +=
            (sender, args) =>
            {
                CurrentChildView = secretaryNavigationService.CurrentChildView;
                Caption = secretaryNavigationService.Caption;
                Icon = secretaryNavigationService.Icon;

                IsHomeViewChecked = _secretaryNavigationService.IsHomeViewChecked;
                IsSpecialtiesViewChecked = _secretaryNavigationService.IsSpecialtiesViewChecked;
                IsGroupsViewChecked = _secretaryNavigationService.IsGroupsViewChecked;
                IsTeachersViewChecked = _secretaryNavigationService.IsTeachersViewChecked;
                IsDisciplinesViewChecked = _secretaryNavigationService.IsDisciplinesViewChecked;
            };

        LoadCurrentUserData();
        }

    private Action<string> UpdateChildView()
    {
        throw new NotImplementedException();
    }

    private void ExecuteShowDisciplineViewModel(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new DisciplinesView(), "Дисциплины", IconChar.Book);
    }

    private void ExecuteLogOutCommand(object obj)
    {
        Thread.CurrentPrincipal = null;

        MainWindow mainWindow = new MainWindow();

        mainWindow.Show();

        OnDestroy.Invoke(this, new EventArgs());
    }

    private void ExecuteShowHomeViewCommand(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new HomeView(), "Главная", IconChar.Home);
    }

    private void ExecuteShowSpecialtiesViewModel(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new SpecialtiesView(), "Специальности",
            IconChar.UserGraduate);
    }

    private void ExecuteShowGroupsViewModel(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new GroupsView(), "Группы",
            IconChar.Users);
    }

    private void ExecuteShowTeachersViewModel(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new TeachersView(), "Преподаватели",
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

        if (user.AvatarPath != null)
        {
            byte[] avatar = File.ReadAllBytes(App.CurrentDirectory + "/Images/Avatars/" + user.AvatarPath);
            CurrentUser.Avatar = avatar;
        }
    }
}