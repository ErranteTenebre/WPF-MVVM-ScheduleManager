using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.DisciplineViewModels;

public class AddDisciplineViewModel : ViewModelBase
{
    private Discipline _discipline = new Discipline();
        
    private string _errorMessage;
    private bool? _dialogResult;

    public Discipline Discipline
    {
        get
        {
            return _discipline;
        }
        set
        {
            if (value != _discipline)
            {
                _discipline = value;
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

    public ICommand AddCommand { get; }

    public event EventHandler OnDestroy; 

    private IDisciplineRepository _disciplineRepository;
  

    public AddDisciplineViewModel(IDisciplineRepository teacherRepository)
    {
        AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
        _disciplineRepository = teacherRepository;
    }

    private bool CanExecuteAddCommand(object obj)
    {
        bool isDataValid;

        if (string.IsNullOrWhiteSpace(Discipline.Name))
        {
            ErrorMessage = "Введите все данные";
            isDataValid = false;
        }

        else {
            isDataValid = true;
        }
          
        return isDataValid;
    }

    private void ExecuteAddCommand(object obj)
    {
        _disciplineRepository.Add(Discipline);

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}