using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.Specialty;

public class EditSpecialtyViewModel : ViewModelBase
{
    private string _errorMessage;
    private bool? _dialogResult;
    private Models.Entities.Specialty _specialty;

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

    public Models.Entities.Specialty Specialty
    {
        get
        {
            return _specialty;
        }

        set
        {
            _specialty = value;
            OnPropertyChanged();
        }
    }

    public ICommand EditSpecialtyCommand { get; }


    public event EventHandler OnDestroy;

    private ISpecialtyRepository _specialtyRepository;

    public EditSpecialtyViewModel(ISpecialtyRepository specialtyRepository)
    {
        EditSpecialtyCommand = new ViewModelCommand(ExecuteEditSpecialtyCommand, CanExecuteEditSpecialtyCommand);
        _specialtyRepository = specialtyRepository;
    }

    private bool CanExecuteEditSpecialtyCommand(object obj)
    {
        bool isDataValid;

        if (string.IsNullOrWhiteSpace(Specialty.Code) || string.IsNullOrWhiteSpace(Specialty.Name) || string.IsNullOrWhiteSpace(Specialty.Acronym))
            isDataValid = false;
        else isDataValid = true;
        return isDataValid;
    }

    private void ExecuteEditSpecialtyCommand(object obj)
    {
        _specialtyRepository.Update(Specialty);

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}