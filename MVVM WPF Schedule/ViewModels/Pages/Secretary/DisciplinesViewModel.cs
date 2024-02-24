using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Popup.DisciplinePopups;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

public class DisciplinesViewModel : ViewModelBase
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

    private IDisciplineRepository _disciplineRepository;
    private List<Discipline> _initialData;
    private List<Discipline> _dataToView;

    public List<Discipline> InitialData
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

    public List<Discipline> DataToView
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

    public DisciplinesViewModel(IDisciplineRepository disciplineRepository)
    {
        _disciplineRepository = disciplineRepository;

        InitialData = _disciplineRepository.GetAll();


        AddCommand = new ViewModelCommand(ExecuteAddCommand);
        EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand, CanExecuteRemoveCommand);
        ClearFilters = new ViewModelCommand(ExecuteClearFiltersCommand);
    }

    private bool CanExecuteEditCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder)
        {
            MessageBox.Show("Выберите дисциплину");
            return false;
        }
        return true;
    }

    private void ExecuteEditCommand(object obj)
    {
        Discipline discipline = (Discipline)SelectedItem;

        Discipline disciplineCopy = (Discipline)discipline.Clone();

        EditDisciplinePopup popup = new EditDisciplinePopup(disciplineCopy);

        if (popup.ShowDialog() == true)
        {
            InitialData = _disciplineRepository.GetAll();
        }
    }

    private bool CanExecuteRemoveCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder)
        {
            MessageBox.Show("Выберит дисциплину");
            return false;
        }
        return true;
    }

    private void ExecuteRemoveCommand(object obj)
    {
        Discipline discipline = (Discipline)SelectedItem;

        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данную специальность?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            _disciplineRepository.Remove(discipline);
            InitialData = _disciplineRepository.GetAll();
        }
    }

    private void ExecuteAddCommand(object obj)
    {
        AddDisciplinePopup popup = new AddDisciplinePopup();

        if (popup.ShowDialog() == true)
        {
            InitialData = _disciplineRepository.GetAll();
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
            DataToView = DataToView.Where(d => d.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }


    }
}