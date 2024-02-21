using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.Services;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Pages.Secretary;
using MVVM_WPF_Schedule.Views.Popup.SpecialtyPopup;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

public class SpecialtiesViewModel : ViewModelBase
{
    private object? _selectedItem;
    private string _searchText;
    public object? SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            if (_selectedItem is Specialty specialty)
            {
                DisciplinesToView = SpecialtyDisciplinesList.Where(sd => sd.SpecialtyCode == specialty.Code)
                    .ToList();
            }
            else
            {
                DisciplinesToView = null;
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
            UpdateSpecialtiesData();
            OnPropertyChanged();
        }
    }

    private ISpecialtyRepository _specialtyRepository;
    private ISpecialtyDisciplinesRepository _specialtyDisciplinesRepository;
    private SecretaryNavigationService _secretaryNavigationService;
    private List<Specialty> _specialtyList;
    private List<Specialty> _dataToView;
    private List<SpecialtyDiscipline> _specialtyDisciplinesList;
    private List<SpecialtyDiscipline> _disciplinesToView;

    public List<Specialty> SpecialtyList
    {
        get
        {
            return _specialtyList;
        }
        set
        {
            _specialtyList = value;
            UpdateSpecialtiesData();
            OnPropertyChanged();
        }
    }

    public List<Specialty> DataToView
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

    public ICommand AddSpecialtyCommand {get;}
    public ICommand EditSpecialtyCommand { get; }
    public ICommand RemoveSpecialtyCommand { get; }
    public ICommand OpenSpecialtiesDisciplinesView { get; }
    public ICommand ClearFilters { get; }

    public List<SpecialtyDiscipline> SpecialtyDisciplinesList
    {
        get
        {
            return _specialtyDisciplinesList;
        }
        set
        {
            _specialtyDisciplinesList = value;
            OnPropertyChanged();
        }
    }

    public List<SpecialtyDiscipline> DisciplinesToView
    {
        get
        {
            return _disciplinesToView;
        }
        set
        {
            _disciplinesToView = value;
            OnPropertyChanged();
        }
    }

    public SpecialtiesViewModel(ISpecialtyRepository specialtyRepository, ISpecialtyDisciplinesRepository specialtyDisciplinesRepository, SecretaryNavigationService secretaryNavigationService)
    {
        _specialtyRepository = specialtyRepository;
        _specialtyDisciplinesRepository = specialtyDisciplinesRepository;
        _secretaryNavigationService = secretaryNavigationService;

        SpecialtyList = _specialtyRepository.GetAll();
        SpecialtyDisciplinesList = _specialtyDisciplinesRepository.GetAll();

        AddSpecialtyCommand = new ViewModelCommand(ExecuteAddSpecialtyCommand);
        EditSpecialtyCommand = new ViewModelCommand(ExecuteEditSpecialtyCommand, CanExecuteEditSpecialtyCommand);
        RemoveSpecialtyCommand = new ViewModelCommand(ExecuteRemoveSpecialtyCommand, CanExecuteRemoveSpecialtyCom);
        OpenSpecialtiesDisciplinesView = new ViewModelCommand(ExecuteOpenSpecialtiesDisciplinesView,
            CanExecuteOpenSpecialtiesDisciplinesView);
        ClearFilters = new ViewModelCommand(ExecuteClearFiltersCommand);
    }

    private void ExecuteClearFiltersCommand(object obj)
    {
        SearchText = "";
        DataToView = SpecialtyList;
    }

    private bool CanExecuteOpenSpecialtiesDisciplinesView(object obj)
    {
        if (SelectedItem == null)
        {
            MessageBox.Show("Выберите специальность");
            return false;
        }

        return true;
    }

    private void ExecuteOpenSpecialtiesDisciplinesView(object obj)
    {
        _secretaryNavigationService.ChangeCurrentChildView(new SpecialtyDisciplinesView(SelectedItem as Specialty), "Дисциплины специальности", IconChar.Book);
    }

    private bool CanExecuteEditSpecialtyCommand(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder) return false;
        return true;
    }

    private void ExecuteEditSpecialtyCommand(object obj)
    {
        Specialty specialty = (Specialty)SelectedItem;

        Specialty specialtyCopy = (Specialty) specialty.Clone();

        EditSpecialtyPopup editSpecialtyPopup = new EditSpecialtyPopup(specialtyCopy);
            
        if (editSpecialtyPopup.ShowDialog() == true)
        {
            SpecialtyList = _specialtyRepository.GetAll();
        }
    }

    private bool CanExecuteRemoveSpecialtyCom(object obj)
    {
        if (SelectedItem == null || SelectedItem == CollectionView.NewItemPlaceholder) return false;
        return true;
    }

    private void ExecuteRemoveSpecialtyCommand(object obj)
    {
        Specialty specialty = (Specialty)SelectedItem;

        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту специальность?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            _specialtyRepository.Remove(specialty);
            SpecialtyList = _specialtyRepository.GetAll();
        }
    }

    private void ExecuteAddSpecialtyCommand(object obj)
    {
        AddSpecialtyPopup specialtyPopup = new AddSpecialtyPopup();


        if (specialtyPopup.ShowDialog() == true)
        {
            SpecialtyList = _specialtyRepository.GetAll();
        }

    }

    private void UpdateSpecialtiesData()
    {
        DataToView = SpecialtyList;
        if (SearchText != null)
        {
            DataToView = SpecialtyList.Where(s =>
                s.Code.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                s.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                s.Acronym.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
        }
    }
}