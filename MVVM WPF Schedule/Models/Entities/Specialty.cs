using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities;

public class Specialty : BaseModel
{
    [Key]
    public string Code { get; set; }
    public string Name { get; set; }
    public string Acronym { get; set; }

}