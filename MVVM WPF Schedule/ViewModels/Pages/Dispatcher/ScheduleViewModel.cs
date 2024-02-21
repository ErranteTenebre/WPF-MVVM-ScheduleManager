using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.Models.View;
using MVVM_WPF_Schedule.ViewModels.Base;
using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Dispatcher
{
    public class ScheduleViewModel : ViewModelBase
    {
        private List<ScheduleItem> _schedule;
        private List<ScheduleItemView> _scheduleView;
        private List<DayOfWeek> _daysOfWeek;
        private List<Group> _groups;
        private List<GroupDiscipline> _groupDisciplines;
        private ScheduleItemView _selectedItem;
        private Group _selectedGroup;
        
        private IScheduleItemRepository _scheduleItemRepository;
        private IDayOfWeekRepository _dayOfWeekRepository;
        private IGroupRepository _groupRepository;
        private IGroupDisciplineRepository _groupDisciplineRepository;

        public ICommand ClearFiltersCommand { get; }
        public ICommand SaveBtnCommand { get; }
        public ICommand RemoveCommand { get; }

        public ScheduleViewModel(IScheduleItemRepository scheduleItemRepository, IDayOfWeekRepository dayOfWeekRepository, IGroupRepository groupRepository, IGroupDisciplineRepository groupDisciplineRepository)
        {
            ClearFiltersCommand = new ViewModelCommand(ExecuteClearFiltersCommand);
            SaveBtnCommand = new ViewModelCommand(ExecuteSaveBtnCommand);
            RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand,CanExecuteRemoveCommand);

            _scheduleItemRepository = scheduleItemRepository;
            _dayOfWeekRepository = dayOfWeekRepository;
            _groupRepository = groupRepository;
            _groupDisciplineRepository = groupDisciplineRepository;

            DaysOfWeek = _dayOfWeekRepository.GetAll();
            Groups = _groupRepository.GetAll();

            Schedule = _scheduleItemRepository.GetAll();
        }

        private bool CanExecuteRemoveCommand(object obj)
        {
            if (SelectedItem == null || SelectedItem.Id == null)
            {
                MessageBox.Show("Выберите пару");
                return false;
            }

            return true;
        }

        private void ExecuteRemoveCommand(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данную пару?",
                "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ScheduleItem scheduleItem = Schedule.FirstOrDefault(i => i.Id == SelectedItem.Id);
                _scheduleItemRepository.Remove(scheduleItem);
                Schedule = _scheduleItemRepository.GetAll();
                UpdateScheduleItems();
            }
        }

        private void ExecuteSaveBtnCommand(object obj)
        {
            GroupDiscipline groupDiscipline = GroupDisciplines.FirstOrDefault(i => i.Id == SelectedItem.GroupDisciplineId);

            if (groupDiscipline == null)
            {
                MessageBox.Show("Ошибка при сохранении");
                return;
            }

            int? teacherId = groupDiscipline.TeacherId;
            if (SelectedItem.Id == null)
            {
                int groupLessonCountInDay = Schedule
                    .Where(i => i.DayOfWeekId == SelectedItem.DayOfWeekId &&
                                i.GroupDiscipline.GroupNumber == SelectedGroup.Number)
                    .Count();
                if (groupLessonCountInDay>= 4)
                {
                    MessageBoxResult result =
                        MessageBox.Show("На данный день уже установлено 4 пары, уверены что хотите добавить еще одну?",
                            "Подтверждение добавления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result != MessageBoxResult.Yes) return; 
                }

                bool teacherIsBusy = Schedule.Where(i => i.GroupDiscipline.TeacherId == teacherId
                                                && i.DayOfWeekId == SelectedItem.DayOfWeekId
                                                && i.LessonNumber == SelectedItem.LessonNumber).Count()>0;
                if (teacherIsBusy)
                {
                        MessageBox.Show("Данный преподаватель уже ведет пару в это время");
                        return;
                }

                    ScheduleItem scheduleItem = new ScheduleItem()
                {
                    GroupDisciplineId =(int) SelectedItem.GroupDisciplineId,
                    LessonNumber = SelectedItem.LessonNumber,
                    DayOfWeekId = SelectedItem.DayOfWeekId,
                };

                _scheduleItemRepository.Add(scheduleItem);
            }
            else
            {
                ScheduleItem scheduleItem = new ScheduleItem()
                {
                    Id = (int) SelectedItem.Id,
                    GroupDisciplineId = (int)SelectedItem.GroupDisciplineId,
                    LessonNumber = SelectedItem.LessonNumber,
                    DayOfWeekId = SelectedItem.DayOfWeekId,
                };

                _scheduleItemRepository.Update(scheduleItem);
            }

            Schedule = _scheduleItemRepository.GetAll();
            UpdateScheduleItems();

        }

        private void ExecuteClearFiltersCommand(object obj)
        {
            SelectedGroup = null;
        }

        public List<ScheduleItem> Schedule
        {
            get => _schedule;
            set
            {
                if (Equals(value, _schedule)) return;
                _schedule = value;
                OnPropertyChanged();
            }
        }

        public List<DayOfWeek> DaysOfWeek
        {
            get => _daysOfWeek;
            set
            {
                if (Equals(value, _daysOfWeek)) return;
                _daysOfWeek = value;
                OnPropertyChanged();
            }
        }

        public List<Group> Groups
        {
            get => _groups;
            set
            {
                if (Equals(value, _groups)) return;
                _groups = value;
                OnPropertyChanged();
            }
        }

        public ScheduleItemView SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (Equals(value, _selectedGroup)) return;
                _selectedGroup = value;
                UpdateScheduleItems();
                UpdateGroupDisciplines();
                OnPropertyChanged();
            }
        }

        private void UpdateGroupDisciplines()
        {
            if (SelectedGroup == null)
            {
                GroupDisciplines = null;
                return;
            }

            GroupDisciplines = _groupDisciplineRepository.GetAll()
                .Where(i => i.GroupNumber == SelectedGroup.Number)
                .ToList();
        }

        public List<ScheduleItemView> ScheduleView
        {
            get => _scheduleView;
            set
            {
                if (Equals(value, _scheduleView)) return;
                _scheduleView = value;

                OnPropertyChanged();
            } 
        }

        public List<GroupDiscipline> GroupDisciplines
        {
            get
            {
                return _groupDisciplines;
            }
            set
            {
                if (Equals(value, _groupDisciplines)) return;
                _groupDisciplines = value;

                OnPropertyChanged();
            }
        }

        private List<ScheduleItemView> SetScheduleTemplate(List<ScheduleItemView> schedule)
        {
            for (int dayOfWeek = 1; dayOfWeek < 7; dayOfWeek++)
            {
                for (int lessonNumber = 1; lessonNumber < 9; lessonNumber++)
                {
                    if (!schedule.Exists(i => i.DayOfWeekId == dayOfWeek && i.LessonNumber == lessonNumber))
                    {
                        schedule.Add(new ScheduleItemView()
                        {
                            DayOfWeekId = dayOfWeek,
                            DayOfWeek = DaysOfWeek.FirstOrDefault(i => i.Id == dayOfWeek).Name,
                            LessonNumber = lessonNumber,
                        });
                    }
                }
            }

            return schedule.OrderBy(i => i.DayOfWeekId)
                .ThenBy(i=>i.LessonNumber)
                .ToList();
        }

        private void UpdateScheduleItems()
        {
            if (SelectedGroup == null)
            {
                ScheduleView = null;
                return;
            }

            ScheduleView = SetScheduleTemplate(
                Schedule.Where(i => i.GroupDiscipline.GroupNumber == SelectedGroup.Number)
                    .Select(i => new ScheduleItemView()
                    {
                        Id = i.Id,
                        GroupDisciplineId = i.GroupDisciplineId,
                        DayOfWeekId = i.DayOfWeekId,
                        DayOfWeek = i.DayOfWeekDay.Name,
                        Discipline = i.GroupDiscipline.Discipline.Name,
                        LessonNumber = i.LessonNumber,
                        Teacher = i.GroupDiscipline.Teacher.FIO,
                    })
                    .ToList());
        }
    }
}
