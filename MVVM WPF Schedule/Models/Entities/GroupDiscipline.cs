using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities
{
    public class GroupDiscipline :BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string GroupNumber { get; set; }
        public int DisciplineId { get; set; }
        public int? TeacherId { get; set; }
        public int HoursCountPerWeek { get; set; }

        public virtual Group Group { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Teacher? Teacher { get; set; }

    }
}
