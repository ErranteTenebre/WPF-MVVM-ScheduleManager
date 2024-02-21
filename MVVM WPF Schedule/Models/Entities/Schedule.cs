using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities
{
    public class ScheduleItem : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int GroupDisciplineId { get; set; }
        public int LessonNumber { get; set; }
        public int DayOfWeekId { get; set; }

        public virtual DayOfWeek DayOfWeekDay { get; set; }
        public virtual GroupDiscipline GroupDiscipline { get; set; }
    }
}
