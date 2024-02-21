namespace MVVM_WPF_Schedule.Models.View
{
    public class ScheduleItemView
    {
        public int? Id { get; set; }
        public int? GroupDisciplineId { get; set; }
        public int? GroupId { get; set; }
        public int LessonNumber { get; set; }
        public int DayOfWeekId { get; set; }
        public string DayOfWeek { get; set; }
        public string Teacher { get; set; }
        public string Discipline { get; set; }
        public string GroupNumber { get; set; }
    }
}
