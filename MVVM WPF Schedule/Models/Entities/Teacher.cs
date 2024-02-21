using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities;

public class Teacher : BaseModel
{
    [Key]
    public int Id { get; set; } 
    public string FIO { get; set; }
    public string Phone { get; set; }
    public int Workload { get; set; }
}