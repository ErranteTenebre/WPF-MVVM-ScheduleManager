using System.Windows.Controls;
using System.Windows.Input;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Pages.Main;
using MVVM_WPF_Schedule.Views.Windows;

namespace MVVM_WPF_Schedule.ViewModels.Windows;

public class MainViewModel : ViewModelBase
{
    private bool isCheckedLogIn = false;
    private UserControl _currentChildView;
    private string _caption;
    private IconChar _icon;

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

    public ICommand ShowStudentScheduleViewCommand { get; }
    public ICommand ShowTeacherScheduleViewCommand { get; }
    public ICommand LogInCommand { get; }

    public bool IsCheckedLogIn
    {
        get => isCheckedLogIn;
        set
        {
            isCheckedLogIn = value;
            OnPropertyChanged();
        }
    }

    public event EventHandler OnDestroy;

    public MainViewModel()
    {
        ShowStudentScheduleViewCommand = new ViewModelCommand(ExecuteShowStudentScheduleViewCommand);
        LogInCommand = new ViewModelCommand(ExecuteLogInCommand);
        ShowTeacherScheduleViewCommand = new ViewModelCommand(ExecuteShowTeacherScheduleViewCommand);
    }

    private void ExecuteShowTeacherScheduleViewCommand(object obj)
    {
        CurrentChildView = new ScheduleTeacher();
        Caption = "Расписание для преподавателя";
        Icon = IconChar.UserGraduate;
    }

    private void ExecuteLogInCommand(object obj)
    {
        LoginForm loginForm = new LoginForm();

        if (loginForm.ShowDialog() == true)
        {
            OnDestroy(this, new EventArgs());
        }

        IsCheckedLogIn = false;
    }

    private void ExecuteShowStudentScheduleViewCommand(object obj)
    {
        CurrentChildView = new ScheduleStudent();
        Caption = "Расписания для студента";
        Icon = IconChar.User;
    }

};



