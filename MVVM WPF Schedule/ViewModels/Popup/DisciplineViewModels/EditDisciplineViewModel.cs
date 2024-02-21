using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.DisciplineViewModels;

public class EditDisciplineViewModel : ViewModelBase
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

    public ICommand EditCommand { get; }

    public event EventHandler OnDestroy; 

    private IDisciplineRepository _disciplineRepository;
  

    public EditDisciplineViewModel(IDisciplineRepository teacherRepository)
    {
        EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        _disciplineRepository = teacherRepository;
    }

    private bool CanExecuteEditCommand(object obj)
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

    private void ExecuteEditCommand(object obj)
    {
        _disciplineRepository.Update(Discipline);

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}