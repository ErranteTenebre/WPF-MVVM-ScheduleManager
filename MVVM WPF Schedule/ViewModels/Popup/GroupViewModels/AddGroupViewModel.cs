using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.DataValidators;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.GroupViewModels;

public class AddGroupViewModel : ViewModelBase
{
    private Group _group = new Group();
        
    private string _errorMessage;
    private bool? _dialogResult;
    private List<Models.Entities.Specialty> _specialtyList;

    public Group Group
    {
        get
        {
            return _group;
        }
        set
        {
            if (value != _group)
            {
                _group = value;
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

    public event EventHandler OnDestroy; 

    private IGroupRepository _groupRepository;
    private ISpecialtyRepository _specialtyRepository;
    private ISpecialtyDisciplinesRepository _specialtyDisciplinesRepository;
    private IGroupDisciplineRepository _groupDisciplineRepository;
    private GroupValidator _groupValidator;

    public AddGroupViewModel(IGroupRepository groupRepository, ISpecialtyRepository specialtyRepository, GroupValidator groupValidator, IGroupDisciplineRepository groupDisciplineRepository, ISpecialtyDisciplinesRepository specialtyDisciplinesRepository)
    {
        AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
        _groupRepository = groupRepository;
        _specialtyRepository = specialtyRepository;
        _groupValidator = groupValidator;
        _groupDisciplineRepository = groupDisciplineRepository;
        _specialtyDisciplinesRepository = specialtyDisciplinesRepository;

        SpecialtyList = _specialtyRepository.GetAll();
    }

    private bool CanExecuteAddCommand(object obj)
    {
        bool isDataValid;

        if (string.IsNullOrWhiteSpace(Group.Number) || string.IsNullOrWhiteSpace(Group.SpecialtyCode))
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
        if (_groupValidator.ValidateModel(Group) != true)
        {
            ErrorMessage = _groupValidator.ErrorMessage;
            return;
        }

        _groupRepository.Add(Group);

        List<SpecialtyDiscipline> specialtyDisciplinesList =  _specialtyDisciplinesRepository.GetAll().Where((sd=>sd.SpecialtyCode == Group.SpecialtyCode)).ToList();

        foreach (SpecialtyDiscipline specialtyDiscipline in specialtyDisciplinesList)
        {
            GroupDiscipline groupDiscipline = new GroupDiscipline()
            {
                GroupNumber = Group.Number,
                DisciplineId = specialtyDiscipline.DisciplineId,
                HoursCountPerWeek = specialtyDiscipline.HoursCountPerWeek,
            };

            _groupDisciplineRepository.Add(groupDiscipline);
        }

        DialogResult = true;
        OnDestroy?.Invoke(this, EventArgs.Empty);
    }
}