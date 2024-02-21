using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities;

public class SpecialtyDiscipline : BaseModel
{
    [Key]
    public int Id { get; set; }
    public string SpecialtyCode { get; set; }
    public int DisciplineId { get; set; }  
    public int HoursCountPerWeek { get; set; }
        
    public virtual Specialty Specialty { get; set; }
    public virtual Discipline Discipline { get; set; }  

}