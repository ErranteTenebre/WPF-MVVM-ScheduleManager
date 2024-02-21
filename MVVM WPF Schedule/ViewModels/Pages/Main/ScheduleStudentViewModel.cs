using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.Models.View;
using MVVM_WPF_Schedule.ViewModels.Base;
using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Main
{
    public class ScheduleStudentViewModel : ViewModelBase
    {
        private List<ScheduleItem> _schedule;
        private List<ScheduleItemView> _scheduleView;
        private List<DayOfWeek> _daysOfWeek;
        private List<Group> _groups;
        private List<GroupDiscipline> _groupDisciplines;
        private Group _selectedGroup;
        private int _selectedDayOfWeek;
        
        private IScheduleItemRepository _scheduleItemRepository;
        private IDayOfWeekRepository _dayOfWeekRepository;
        private IGroupRepository _groupRepository;

        public ICommand ClearFiltersCommand { get; }

        public ScheduleStudentViewModel(IScheduleItemRepository scheduleItemRepository, IDayOfWeekRepository dayOfWeekRepository, IGroupRepository groupRepository)
        {
            ClearFiltersCommand = new ViewModelCommand(ExecuteClearFiltersCommand);

            _scheduleItemRepository = scheduleItemRepository;
            _dayOfWeekRepository = dayOfWeekRepository;
            _groupRepository = groupRepository;

            DaysOfWeek = _dayOfWeekRepository.GetAll();
            Groups = _groupRepository.GetAll();

            Schedule = _scheduleItemRepository.GetAll();
        }

        private void ExecuteClearFiltersCommand(object obj)
        {
            SelectedGroup = null;
            SelectedDayOfWeek = 0;
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

        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if (Equals(value, _selectedGroup)) return;
                _selectedGroup = value;
                UpdateScheduleItems();
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

        public int SelectedDayOfWeek
        {
            get => _selectedDayOfWeek;
            set
            {
                if (value == _selectedDayOfWeek) return;
                _selectedDayOfWeek = value;
                UpdateScheduleItems();
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

        private List<ScheduleItemView> SetScheduleTemplateForDay(List<ScheduleItemView> schedule, int dayOfWeek)
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

            return schedule.OrderBy(i => i.DayOfWeekId)
                .ThenBy(i => i.LessonNumber)
                .ToList();
        }

        private void UpdateScheduleItems()
        {
            if (SelectedGroup == null)
            {
                ScheduleView = null;
                return;
            }

            List<ScheduleItem> filteredSchedule = Schedule.Where(i => i.GroupDiscipline.GroupNumber == SelectedGroup.Number).ToList();

            if (SelectedDayOfWeek == 0)
                {
                ScheduleView = SetScheduleTemplate(filteredSchedule.Select(i => new ScheduleItemView()
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
            else
            {
                filteredSchedule = filteredSchedule.Where(i => i.DayOfWeekId == SelectedDayOfWeek).ToList();

                ScheduleView = SetScheduleTemplateForDay(filteredSchedule.Select(i => new ScheduleItemView()
                    {
                        Id = i.Id,
                        GroupDisciplineId = i.GroupDisciplineId,
                        DayOfWeekId = i.DayOfWeekId,
                        DayOfWeek = i.DayOfWeekDay.Name,
                        Discipline = i.GroupDiscipline.Discipline.Name,
                        LessonNumber = i.LessonNumber,
                        Teacher = i.GroupDiscipline.Teacher.FIO,
                    })
                    .ToList(), SelectedDayOfWeek);
            }



            
        }
    }
}
