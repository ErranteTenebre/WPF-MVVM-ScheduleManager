namespace MVVM_WPF_Schedule.Models.Entities;

public abstract class BaseModel : ICloneable
{
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}