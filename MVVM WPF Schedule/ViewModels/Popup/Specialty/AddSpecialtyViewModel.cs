using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.Specialty;

public class AddSpecialtyViewModel : ViewModelBase
{
    private string _specialtyCode;
    private string _specialtyName;
    private string _specialtyAcronym;
    private string _errorMessage;
    private bool? _dialogResult;

    public string SpecialtyCode
    {
        get
        {
            return _specialtyCode;
        }

        set
        {
            _specialtyCode = value;
            OnPropertyChanged();
        }
    }
    public string SpecialtyName
    {
        get
        {
            return _specialtyName;
        }

        set
        {
            _specialtyName = value;
            OnPropertyChanged();
        }
    }
    public string SpecialtyAcronym
    {
        get
        {
            return _specialtyAcronym;
        }

        set
        {
            _specialtyAcronym = value;
            OnPropertyChanged();
        }
    }

    public string ErrorMessage
    {
        get { return _errorMessage; }
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

    public ICommand AddSpecialtyCommand { get; }

            
    public event EventHandler OnDestroy;

    private ISpecialtyRepository _specialtyRepository;

    public AddSpecialtyViewModel(ISpecialtyRepository specialtyRepository)
    {
        AddSpecialtyCommand = new ViewModelCommand(ExecuteAddSpecialtyCommand, CanExecuteAddSpecialtyCommand);
        _specialtyRepository = specialtyRepository;
    }

    private bool CanExecuteAddSpecialtyCommand(object obj)
    {
        bool isDataValid;

        if (string.IsNullOrWhiteSpace(SpecialtyCode) || string.IsNullOrWhiteSpace(SpecialtyName) || string.IsNullOrWhiteSpace(SpecialtyAcronym))
            isDataValid = false;
        else isDataValid = true;
        return isDataValid;
    }

    private void ExecuteAddSpecialtyCommand(object obj)
    {
        if (_specialtyRepository.IsExist(SpecialtyCode, SpecialtyName, SpecialtyAcronym))
        {
            ErrorMessage = "Специальность уже существует";
            return;
        }

        Models.Entities.Specialty specialty = new Models.Entities.Specialty()
        {
            Code = SpecialtyCode,
            Name = SpecialtyName,
            Acronym = SpecialtyAcronym,
        };

        _specialtyRepository.Add(specialty);

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}