using CursachApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CursachApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private SecureString _password;
        private string _errorMessage;
        private bool isViewVisible = true;

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
        public bool IsViewVisible
        {
            get
            {
                return isViewVisible;
            }

            set
            {
                isViewVisible = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            ShowPasswordCommand = new ViewModelCommand(ExecuteShowPasswordCommand);

        }


        private void ExecuteShowPasswordCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
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

        private void ExecuteLoginCommand(object obj)
        {
            bool isUserValid = _userRepository.Authentificate(new NetworkCredential(UserName, Password));

            if (isUserValid)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), []);
                isViewVisible = false;
            }
            else
            {
                ErrorMessage = "Неверный логин или пароль";
            }
        }
    }
}
