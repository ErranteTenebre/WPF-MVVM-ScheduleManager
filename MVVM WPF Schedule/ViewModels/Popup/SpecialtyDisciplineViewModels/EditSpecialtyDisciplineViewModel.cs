using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Popup.SpecialtyDisciplineViewModels
{
    public class EditSpecialtyDisciplineViewModel : ViewModelBase
    {
        private SpecialtyDiscipline _specialtyDiscipline = new SpecialtyDiscipline();
        private ISpecialtyDisciplinesRepository _specialtyDisciplinesRepository;

        public EditSpecialtyDisciplineViewModel(ISpecialtyDisciplinesRepository specialtyDisciplinesRepository)
        {
            _specialtyDisciplinesRepository = specialtyDisciplinesRepository;

            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
        }

        private bool CanExecuteEditCommand(object obj)
        {
            if (SpecialtyDiscipline.DisciplineId != 0 && SpecialtyDiscipline.HoursCountPerWeek != 0)
            {
                return true;
            }
            return false;
        }

        private void ExecuteEditCommand(object obj)
        {
            _specialtyDisciplinesRepository.Update(SpecialtyDiscipline);

            OnDestroy.Invoke(this, EventArgs.Empty);
        }

        public ICommand EditCommand { get; }
        public event EventHandler OnDestroy;


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

    }
}
