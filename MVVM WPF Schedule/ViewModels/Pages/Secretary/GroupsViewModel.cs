using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.Services;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Pages.Secretary;
using MVVM_WPF_Schedule.Views.Popup.Group;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

public class GroupsViewModel : ViewModelBase
{
    private Group _selectedItem;
    private string _searchText;
    private List<Specialty> _specialtyList;
    private bool? _isBudget;
    private string _specialtyCode;
    private List<GroupDiscipline> _groupDisciplineList;
    private SecretaryNavigationService _secretaryNavigationService;
    public Group SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            if (_selectedItem != null)
            {
                GroupDisciplineList = _groupDisciplineRepository.GetAll()
                    .Where(gd => gd.GroupNumber == _selectedItem.Number).ToList();
            }
            else
            {
                GroupDisciplineList = null;
            }
            OnPropertyChanged();

        }
    }
    public string SearchText
    {
        get
        {
            return _searchText;
        }

        set
        {
            _searchText = value;
            UpdateData();
            OnPropertyChanged();
        }
    }

    public List<Specialty> SpecialtyList
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

    public bool? IsBudget
    {
        get
        {
            return _isBudget;
        }

        set
        {
            _isBudget = value;
            UpdateData();
            OnPropertyChanged();
        }
    }
    public string SpecialtyCode
    {
        get
        {
            return _specialtyCode;
        }
        set
        {
            _specialtyCode = value;
            UpdateData();
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }
    public ICommand ClearFilters { get; }
    public ICommand ShowGroupDisciplinesViewCommand { get; }

    private IGroupRepository _groupRepository;
    private ISpecialtyRepository _specialtyRepository;
    private IGroupDisciplineRepository _groupDisciplineRepository;
    private List<Group> _GroupList;
    private List<Group> _dataToView;

    public List<Group> GroupList
    {
        get
        {
            return _GroupList;
        }
        set
        {
            _GroupList = value;
            UpdateData();
            OnPropertyChanged();
        }
    }

    public List<Group> DataToView
    {
        get
        {
            return _dataToView;
        }
        set
        {
            _dataToView = value;
            OnPropertyChanged();
        }
    }

    public List<GroupDiscipline> GroupDisciplineList
    {
        get
        {
            return _groupDisciplineList;
        }
        set
        {
            _groupDisciplineList = value;
            OnPropertyChanged();
        }
    }

    public GroupsViewModel(IGroupRepository groupRepository, ISpecialtyRepository specialtyRepository, IGroupDisciplineRepository groupDisciplineRepository, SecretaryNavigationService secretaryNavigationService)
    {
        _groupRepository = groupRepository;
        _specialtyRepository = specialtyRepository;
        _groupDisciplineRepository = groupDisciplineRepository;
        _secretaryNavigationService = secretaryNavigationService;

        GroupList = _groupRepository.GetAll();
        SpecialtyList = _specialtyRepository.GetAll();

        AddCommand = new ViewModelCommand(ExecuteAddCommand);
        EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand, CanExecuteRemoveCommand);
        ClearFilters = new ViewModelCommand(ExecuteClearFiltersCommand);
        ShowGroupDisciplinesViewCommand = new ViewModelCommand(ExecuteShowGroupDisciplinesViewCommand, CanExecuteShowGroupDisciplinesViewCommand);
    }

    private bool CanExecuteShowGroupDisciplinesViewCommand(object obj)
    {
        if (SelectedItem == null)
        {
            MessageBox.Show("Выберите группу");
            return false;
        }

        return true;
    }

    private void ExecuteShowGroupDisciplinesViewCommand(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new GroupDisciplinesView(SelectedItem), "Дисциплины группы", IconChar.Book);
    }

    private void ExecuteClearFiltersCommand(object obj)
    {
        SearchText = "";
        SpecialtyCode = null;
        IsBudget = null;
        DataToView = GroupList;
    }

    private bool CanExecuteEditCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder) return false;
        return true;
    }

    private void ExecuteEditCommand(object obj)
    {
        Group group = (Group)SelectedItem;

        Group groupCopy = (Group)group.Clone();

        EditGroupPopup editGroupPopup = new EditGroupPopup(groupCopy);

        if (editGroupPopup.ShowDialog() == true)
        {
            GroupList = _groupRepository.GetAll();
        }
    }

    private bool CanExecuteRemoveCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder) return false;
        return true;
    }

    private void ExecuteRemoveCommand(object obj)
    {
        Group Group = (Group)SelectedItem;

        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту группу?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            _groupRepository.Remove(Group);
            GroupList = _groupRepository.GetAll();
        }
    }

    private void ExecuteAddCommand(object obj)
    {
        AddGroupPopup GroupPopup = new AddGroupPopup();

        if (GroupPopup.ShowDialog() == true)
        {
            GroupList = _groupRepository.GetAll();
        }

    }

    private void UpdateData()
    {
        DataToView = GroupList;
        if (!(SearchText == null || SearchText == ""))
        {
            DataToView = DataToView.Where(g =>
                g.Number.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
        }

        if (SpecialtyCode != null)
        {
            DataToView = DataToView.Where(g => g.SpecialtyCode == SpecialtyCode).ToList();
        }

        if (IsBudget != null)
        {
            DataToView = DataToView.Where(g => g.IsBudget == IsBudget).ToList();
        }
    }
}