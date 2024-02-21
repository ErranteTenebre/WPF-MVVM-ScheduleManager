using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities;

public class Discipline : BaseModel
{
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; }    
}