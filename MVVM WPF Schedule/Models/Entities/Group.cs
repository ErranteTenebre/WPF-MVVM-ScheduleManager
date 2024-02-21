using System.ComponentModel.DataAnnotations;

namespace MVVM_WPF_Schedule.Models.Entities;

public class Group : BaseModel
{
    [Key]
    public string Number { get; set; }
    public bool IsBudget { get; set; }
    public int AdmissionYear { get; set; }
    public string SpecialtyCode { get; set; }
    public virtual Specialty Specialty { get; set; }
    public virtual ICollection<GroupDiscipline> GroupDisciplines { get; set; }

}