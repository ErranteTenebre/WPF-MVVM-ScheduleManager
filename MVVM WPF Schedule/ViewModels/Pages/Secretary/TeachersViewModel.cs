using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Popup.TeacherPopups;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

public class TeachersViewModel : ViewModelBase
{
    private object _selectedItem;
    private string _searchText;

    public object SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
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

    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }
    public ICommand ClearFilters { get; }

    private ITeacherRepository _teacherRepository;
    private List<Teacher> _initialData;
    private List<Teacher> _dataToView;

    public List<Teacher> InitialData
    {
        get
        {
            return _initialData;
        }
        set
        {
            _initialData = value;
            UpdateData();
            OnPropertyChanged();
        }
    }

    public List<Teacher> DataToView
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

    public TeachersViewModel(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;

        InitialData = _teacherRepository.GetAll();


        AddCommand = new ViewModelCommand(ExecuteAddCommand);
        EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand, CanExecuteRemoveCommand);
        ClearFilters = new ViewModelCommand(ExecuteClearFiltersCommand);
    }

    private bool CanExecuteEditCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder)
        {
            MessageBox.Show("Выберите преподавателя");
            return false;
        }
        return true;
    }

    private void ExecuteEditCommand(object obj)
    {
        Teacher Teacher = (Teacher)SelectedItem;

        Teacher groupCopy = (Teacher)Teacher.Clone();

        EditTeacherPopup editGroupPopup = new EditTeacherPopup(groupCopy);

        if (editGroupPopup.ShowDialog() == true)
        {
            InitialData = _teacherRepository.GetAll();
        }
    }

    private bool CanExecuteRemoveCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder)
        {
            MessageBox.Show("Выберите преподавателя");
            return false;
        }
        return true;
    }

    private void ExecuteRemoveCommand(object obj)
    {
        Teacher Teacher = (Teacher)SelectedItem;

        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого преподавателя?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            _teacherRepository.Remove(Teacher);
            InitialData = _teacherRepository.GetAll();
        }
    }

    private void ExecuteAddCommand(object obj)
    {
        AddTeacherPopup popup = new AddTeacherPopup();

        if (popup.ShowDialog() == true)
        {
            InitialData = _teacherRepository.GetAll();
        }

    }

    private void ExecuteClearFiltersCommand(object obj)
    {
        SearchText = null;
        DataToView = InitialData;
    }

    private void UpdateData()
    {
        DataToView = InitialData;
        if (!(SearchText == null || SearchText == ""))
        {
            DataToView = DataToView.Where(t => t.FIO.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }


    }
}