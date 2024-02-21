using System.Net;
using System.Security;
using System.Security.Principal;
using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Windows;

namespace MVVM_WPF_Schedule.ViewModels.Windows;

public class LoginViewModel : ViewModelBase
{
    public event EventHandler OnDestroy;

    private string _userName;
    private SecureString _password;
    private string _errorMessage;

    private IUserRepository _userRepository;

    public string UserName
    {
        get
        {
            return _userName;
        }

        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }
    public SecureString Password
    {
        get
        {
            return _password;
        }

        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    public string ErrorMessage
    {
        get
        {
            return _errorMessage;
        }

        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand LogInCommand { get; }
    public ICommand RestorePassCommand { get; }

    public LoginViewModel(IUserRepository userRepository)
    {
        LogInCommand = new ViewModelCommand(ExecuteLogInCommand, CanExecuteLogInCommand);
        RestorePassCommand = new ViewModelCommand(ExecuteRestorePassCommand);

        _userRepository = userRepository;
    }
    private void ExecuteRestorePassCommand(object obj)
    {
        ErrorMessage = "Обратитесь к администратору для восстановления пароля";
    }

    private bool CanExecuteLogInCommand(object obj)
    {
        bool validData;

        if (string.IsNullOrWhiteSpace(UserName) || Password == null)
        {
            validData = false;
        }
        else
        {
            validData = true;
        }

        return validData;
    }

    private void ExecuteLogInCommand(object obj)
    {
        bool isUserValid = _userRepository.Authentificate(new NetworkCredential(UserName, Password));

        if (isUserValid)
        {
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), []);
            string UserPost = _userRepository.GetUserRole(UserName);

            OnDestroy(this, EventArgs.Empty);
            OpenWindowAccordingToRole(UserPost);
        }
        else
        {
            ErrorMessage = "Неверный логин или пароль";
        }
    }

    private void OpenWindowAccordingToRole(string userPost)
    {
        switch (userPost)
        {
            case "Секретарь":
            {
                SecretaryForm secretaryForm = new SecretaryForm();

                secretaryForm.Show();

                break;
            }
            case "Диспетчер":
            {
                DispatcherForm dispatcherForm = new DispatcherForm();

                dispatcherForm.Show();

                break;
            }
        }
    }
}