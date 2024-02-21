using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.Views.Popup.SpecialtyDisciplinePopups;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Secretary
{
    public class SpecialtyDisciplinesViewModel : ViewModelBase
    {
        private ISpecialtyDisciplinesRepository _specialtyDisciplinesRepository;
        private IDisciplineRepository _disciplineRepository;
        private List<SpecialtyDiscipline> _specialtyDisciplinesList;
        private SpecialtyDiscipline _selectedItem;
        private Specialty _selectedSpecialty;

        public SpecialtyDisciplinesViewModel(ISpecialtyDisciplinesRepository specialtyDisciplinesRepository, IDisciplineRepository disciplineRepository)
        {
            _specialtyDisciplinesRepository = specialtyDisciplinesRepository;
            _disciplineRepository = disciplineRepository;
            AddCommand = new ViewModelCommand(ExecuteAddAction);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteAction, CanExecuteDeleteAction);
            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        }

        private bool CanExecuteEditCommand(object obj)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Выберите дисциплину");
                return false;
            }

            return true;
        }

        private void ExecuteEditCommand(object obj)
        {
            SpecialtyDiscipline specialtyDiscipline = (SpecialtyDiscipline)SelectedItem;

            SpecialtyDiscipline specialtyDisciplineCopy = (SpecialtyDiscipline)specialtyDiscipline.Clone();

            EditSpecialtyDisciplinePopup popup = new EditSpecialtyDisciplinePopup(specialtyDisciplineCopy);

            if (popup.ShowDialog() == true)
            {
                SpecialtyDisciplinesList = _specialtyDisciplinesRepository.GetAllBySpecialty(SelectedSpecialty.Code);
            }
        }

        private bool CanExecuteDeleteAction(object obj)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Выберите дисциплину");
                return false;
            }

            return true;
        }

        private void ExecuteDeleteAction(object obj)
        {
            if (MessageBox.Show("Вы действительно хотите открепить данную дисциплину от специальности ? ", "Удаление дисциплины специальности", MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes)
            {
                _specialtyDisciplinesRepository.Remove(SelectedItem);
                SpecialtyDisciplinesList = _specialtyDisciplinesRepository.GetAllBySpecialty(SelectedSpecialty.Code);
            }

           
        }

        private void ExecuteAddAction(object obj)
        {
            AddSpecialtyDisciplinePopup popup = new AddSpecialtyDisciplinePopup(SelectedSpecialty);

            if (popup.ShowDialog() == true)
            {
                SpecialtyDisciplinesList = _specialtyDisciplinesRepository.GetAllBySpecialty(SelectedSpecialty.Code);
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

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

        public SpecialtyDiscipline SelectedItem
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

        public Specialty SelectedSpecialty
        {
            get
            {
                return _selectedSpecialty;
            }
            set
            {
                _selectedSpecialty = value;
                SpecialtyDisciplinesList = _specialtyDisciplinesRepository.GetAllBySpecialty(SelectedSpecialty.Code);
                OnPropertyChanged();
            }
        }


    }
}
