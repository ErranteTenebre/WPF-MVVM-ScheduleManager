using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.DataValidators;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.TeacherViewModels;

public class EditTeacherViewModel : ViewModelBase
{
    private Teacher _teacher;
        
    private string _errorMessage;
    private bool? _dialogResult;

    public Teacher Teacher
    {
        get
        {
            return _teacher;
        }
        set
        {
            if (value != _teacher)
            {
                _teacher = value;
                OnPropertyChanged();
            }
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

    public bool? DialogResult
    {
        get
        {
            return _dialogResult;
        }

        set
        {
            _dialogResult = value;
        }
    }

    public ICommand EditCommand { get; }

    public event EventHandler OnDestroy; 

    private ITeacherRepository _teacherRepository;
    private TeacherValidator _teacherValidator;

    public EditTeacherViewModel(ITeacherRepository teacherRepository, TeacherValidator TeacherValidator)
    {
        EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        _teacherRepository = teacherRepository;
        _teacherValidator = TeacherValidator;
    }

    private bool CanExecuteEditCommand(object obj)
    {
        bool isDataValid;

        if (string.IsNullOrWhiteSpace(Teacher.FIO) || string.IsNullOrWhiteSpace(Teacher.Phone))
        {
            ErrorMessage = "Введите все данные";
            isDataValid = false;
        }

        else {
            isDataValid = true;
        }
          
        return isDataValid;
    }

    private void ExecuteEditCommand(object obj)
    {
        if (_teacherValidator.ValidateModel(Teacher) != true)
        {
            ErrorMessage = _teacherValidator.ErrorMessage;
            return;
        }

        _teacherRepository.Update(Teacher);

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}