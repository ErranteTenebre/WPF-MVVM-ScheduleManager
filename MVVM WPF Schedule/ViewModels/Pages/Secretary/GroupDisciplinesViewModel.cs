using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Secretary
{
    public class GroupDisciplinesViewModel : ViewModelBase
    {
        private List<GroupDiscipline> _groupDisciplineList;
        private List<Teacher> _teacherList;
        private GroupDiscipline _selectedItem;
        private Group _group;
        private bool _isEditPanelVisible = false;

        private IGroupDisciplineRepository _groupDisciplineRepository;
        private ITeacherRepository _teacherRepository;
        
        public GroupDisciplinesViewModel(IGroupDisciplineRepository groupDisciplineRepository, ITeacherRepository teacherRepository)
        {
            _groupDisciplineRepository = groupDisciplineRepository;
            _teacherRepository = teacherRepository;

            TeacherList = _teacherRepository.GetAll();

            EditCommand = new ViewModelCommand(ExecuteEditCommand, CanExecuteEditCommand);
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand(object obj)
        {
            _groupDisciplineRepository.Update(SelectedItem);
            GroupDisciplineList = _groupDisciplineRepository.GetAll().Where(gd => gd.GroupNumber == _group.Number)
                .ToList();
            IsEditPanelVisible = false;
        }

        private bool CanExecuteEditCommand(object obj)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Выберите дисциплину группы");
                return false;
            }

            return true;
        }

        private void ExecuteEditCommand(object obj)
        {
            IsEditPanelVisible = true;
        }

        public ICommand EditCommand { get; }
        public ICommand SaveCommand { get; }

        public List<GroupDiscipline> GroupDisciplineList
        {
            get => _groupDisciplineList;
            set
            {
                if (Equals(value, _groupDisciplineList)) return;
                _groupDisciplineList = value;
                OnPropertyChanged();
            }
        }

        public GroupDiscipline SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Group Group
        {
            get => _group;
            set
            {
                if (Equals(value, _group)) return;
                _group = value;
                OnPropertyChanged();
                GroupDisciplineList = _groupDisciplineRepository.GetAll().Where(gd => gd.GroupNumber == _group.Number)
                    .ToList();
                OnPropertyChanged();
            }
        }

        public bool IsEditPanelVisible
        {
            get => _isEditPanelVisible;
            set
            {
                if (value == _isEditPanelVisible) return;
                _isEditPanelVisible = value;
                OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        public List<Teacher> TeacherList
        {
            get => _teacherList;
            set => _teacherList = value;
        }
    }
}
