namespace MVVM_WPF_Schedule.Models.Entities;

public class User : BaseModel
{
    public int Id { get; set; }
    public string FIO { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Login { get; set; }
    public string AvatarName { get; set; }
    public int PostId { get; set; }

    public virtual Post Post { get; set; }
}