using System.IO;

namespace MVVM_WPF_Schedule.Models;

public class CurrentUser
{
    public int Id { get; set; }
    public string FIO { get; set; }
    private byte[] _avatar;
    public byte[] Avatar
    {
        get
        {
            if (_avatar == null)
            {
                byte[] bytes = File.ReadAllBytes(App.CurrentDirectory+"/Images/Avatars/default-avatar.jpg");
                return bytes;
            }
            else return _avatar;
        }
        set
        {
            _avatar = value;
        }
    }

}