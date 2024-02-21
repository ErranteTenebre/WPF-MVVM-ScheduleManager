using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.SpecialtyDisciplineViewModels
{
    public class AddSpecialtyDisciplineViewModel : ViewModelBase
    {
        private List<Discipline> _unusedDisciplineList;
        private SpecialtyDiscipline _specialtyDiscipline = new SpecialtyDiscipline();
        private ISpecialtyDisciplinesRepository _specialtyDisciplinesRepository;
        private Models.Entities.Specialty _specialty;

        public AddSpecialtyDisciplineViewModel(ISpecialtyDisciplinesRepository specialtyDisciplinesRepository)
        {
            _specialtyDisciplinesRepository = specialtyDisciplinesRepository;

            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
        }

        private bool CanExecuteAddCommand(object obj)
        {
            if (SpecialtyDiscipline.DisciplineId != 0 && SpecialtyDiscipline.HoursCountPerWeek != 0)
            {
                return true;
            }
            return false;
        }

        private void ExecuteAddCommand(object obj)
        {
            _specialtyDisciplinesRepository.Add(SpecialtyDiscipline);

            OnDestroy.Invoke(this, EventArgs.Empty);
        }

        public ICommand AddCommand { get; }
        public event EventHandler OnDestroy;

        public List<Discipline> UnusedDisciplineList
        {
            get { return _unusedDisciplineList; }
            set
            {
                if (Equals(value, _unusedDisciplineList)) return;
                _unusedDisciplineList = value;
                OnPropertyChanged();
            }
        }

        public SpecialtyDiscipline SpecialtyDiscipline
        {
            get { return _specialtyDiscipline; }
            set
            {
                if (Equals(value, _specialtyDiscipline)) return;
                _specialtyDiscipline = value;
                OnPropertyChanged();
            }
        }

        public Models.Entities.Specialty Specialty
        {
            get { return _specialty; }
            set
            {
                if (Equals(value, _specialty)) return;
                _specialty = value;
                UnusedDisciplineList = _specialtyDisciplinesRepository.GetUnusedDisciplines(Specialty.Code);
                SpecialtyDiscipline.SpecialtyCode = Specialty.Code;
                OnPropertyChanged();
            }
        }
    }
}
