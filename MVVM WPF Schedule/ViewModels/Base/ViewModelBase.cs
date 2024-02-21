using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_WPF_Schedule.ViewModels.Base;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string property = "")
    {
        if (property != null)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
    {
        if (Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(PropertyName);
        return true;
    }

}