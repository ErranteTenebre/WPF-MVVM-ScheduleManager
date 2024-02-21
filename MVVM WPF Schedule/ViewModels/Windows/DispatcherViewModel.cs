using System.IO;
using System.Security.Principal;
using System.Windows.Controls;
using System.Windows.Input;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Pages;
using MVVM_WPF_Schedule.Views.Pages.Dispatcher;
using MVVM_WPF_Schedule.Views.Windows;

namespace MVVM_WPF_Schedule.ViewModels.Windows;

public class DispatcherViewModel : ViewModelBase
{
    private readonly IUserRepository _userRepository;
    private UserControl _currentChildView;
    private string _caption;
    private IconChar _icon;

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

    public ICommand ShowHomeViewCommand { get; }
    public ICommand ShowScheduleViewCommand { get; }
    public ICommand LogOutCommand { get; }

    public event EventHandler OnDestroy;

    public DispatcherViewModel(IUserRepository userRepository)
    {
        ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
        LogOutCommand = new ViewModelCommand(ExecuteLogOutCommand);
        ShowScheduleViewCommand = new ViewModelCommand(ExecuteShowScheduleViewCommand);

        _userRepository = userRepository;

        LoadCurrentUserData();
    }

    private void ExecuteShowScheduleViewCommand(object obj)
    {
        CurrentChildView = new ScheduleView();
        Caption = "Расписание";
        Icon = IconChar.Table;
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
        CurrentChildView = new HomeView();
        Caption = "Главная";
        Icon = IconChar.Home;
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
};



