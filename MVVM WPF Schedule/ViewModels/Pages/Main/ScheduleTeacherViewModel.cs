using System.Windows.Input;
using MVVM_WPF_Schedule.Infrastructure.Repositories.Interfaces;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.Models.View;
using MVVM_WPF_Schedule.ViewModels.Base;
using DayOfWeek = MVVM_WPF_Schedule.Models.Entities.DayOfWeek;

namespace MVVM_WPF_Schedule.ViewModels.Pages.Main
{
    public class ScheduleTeacherViewModel : ViewModelBase
    {
        private List<ScheduleItem> _schedule;
        private List<ScheduleItemView> _scheduleView;
        private List<DayOfWeek> _daysOfWeek;
        private List<Teacher> _teachers;
        private Teacher _selectedTeacher;
        private int _selectedDayOfWeek;

        private IScheduleItemRepository _scheduleItemRepository;
        private IDayOfWeekRepository _dayOfWeekRepository;
        private ITeacherRepository _teacherRepository;

        public ICommand ClearFiltersCommand { get; }

        public ScheduleTeacherViewModel(IScheduleItemRepository scheduleItemRepository, IDayOfWeekRepository dayOfWeekRepository, ITeacherRepository teacherRepository)
        {
            ClearFiltersCommand = new ViewModelCommand(ExecuteClearFiltersCommand);

            _scheduleItemRepository = scheduleItemRepository;
            _dayOfWeekRepository = dayOfWeekRepository;
            _teacherRepository = teacherRepository;

            DaysOfWeek = _dayOfWeekRepository.GetAll();
            Teachers = _teacherRepository.GetAll();

            Schedule = _scheduleItemRepository.GetAll();
        }

        private void ExecuteClearFiltersCommand(object obj)
        {
            SelectedTeacher = null;
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

        public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set
            {
                if (Equals(value, _selectedTeacher)) return;
                _selectedTeacher = value;
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

        public List<Teacher> Teachers
        {
            get => _teachers;
            set
            {
                if (Equals(value, _teachers)) return;
                _teachers = value;
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

        private void UpdateScheduleItems()
        {
            if (SelectedTeacher == null)
            {
                ScheduleView = null;
                return;
            }

            var filteredSchedule = Schedule.Where(i => i.GroupDiscipline.TeacherId == SelectedTeacher.Id).ToList();

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
                    GroupNumber = i.GroupDiscipline.Group.Number,
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
                    GroupNumber = i.GroupDiscipline.Group.Number,
                })
                .ToList(), SelectedDayOfWeek);
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
                .ThenBy(i => i.LessonNumber)
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
    }
}