using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.GroupViewModels;

public class EditGroupViewModel : ViewModelBase
{
    private string _errorMessage;
    private bool? _dialogResult;
    private Group _group;
    private List<Models.Entities.Specialty> _specialtyList;

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

    public Group Group
    {
        get
        {
            return _group;
        }

        set
        {
            _group = value;
            OnPropertyChanged();
        }
    }
    public List<Models.Entities.Specialty> SpecialtyList
    {
        get
        {
            return _specialtyList;
        }

        set
        {
            _specialtyList = value;
            OnPropertyChanged();
        }
    }
    public ICommand EditCommand { get; }

    public event EventHandler OnDestroy;

    private IGroupRepository _groupRepository;
    private ISpecialtyRepository _specialtyRepository;

    public EditGroupViewModel(IGroupRepository groupRepository, ISpecialtyRepository specialtyRepository)
    {
        EditCommand = new ViewModelCommand(ExecuteEditSpecialtyCommand, CanExecuteEditSpecialtyCommand);
        _groupRepository = groupRepository;
        _specialtyRepository = specialtyRepository;
        SpecialtyList = _specialtyRepository.GetAll();
    }

    private bool CanExecuteEditSpecialtyCommand(object obj)
    {
        bool isDataValid;

        if (false)
            isDataValid = false;
        else isDataValid = true;
        return isDataValid;
    }

    private void ExecuteEditSpecialtyCommand(object obj)
    {
        _groupRepository.Update(Group);

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}