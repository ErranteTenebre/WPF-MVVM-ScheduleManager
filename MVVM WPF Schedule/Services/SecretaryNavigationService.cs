using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.Views.Pages;
using MVVM_WPF_Schedule.Views.Pages.Secretary;

namespace MVVM_WPF_Schedule.Services;

public class SecretaryNavigationService : INotifyPropertyChanged
{
    private UserControl _currentChildView;
    private IconChar _icon;
    private string _caption;

    private bool isSpecialtiesViewChecked = true;
    private bool isGroupsViewChecked = false;
    private bool isTeachersViewChecked = false;
    private bool isDisciplinesViewChecked = false;

    public SecretaryNavigationService()
    {
    }

    public UserControl CurrentChildView
    {
        get { return _currentChildView; }
        set
        {
            _currentChildView = value;
            OnPropertyChanged();
        }
    }

    public IconChar Icon
    {
        get { return _icon; }
        set
        {
            _icon = value;
            OnPropertyChanged();
        }
    }

    public string Caption
    {
        get { return _caption; }
        set
        {
            _caption = value;
            OnPropertyChanged();
        }
    }

    public bool IsSpecialtiesViewChecked
    {
        get { return isSpecialtiesViewChecked; }
        set
        {
            isSpecialtiesViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsGroupsViewChecked
    {
        get { return isGroupsViewChecked; }
        set
        {
            isGroupsViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsDisciplinesViewChecked
    {
        get { return isDisciplinesViewChecked; }
        set
        {
            isDisciplinesViewChecked = value;
            OnPropertyChanged();
        }
    }

    public bool IsTeachersViewChecked
    {
        get { return isTeachersViewChecked; }
        set
        {
            isTeachersViewChecked = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberNameAttribute] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public void ChangeCurrentChildView(UserControl newView, string caption, IconChar icon)
    {
        CurrentChildView = newView;
        Caption = caption;
        Icon = icon;
        ChangeNavigationChecked();
    }

    private void ChangeNavigationChecked()
    {
        IsSpecialtiesViewChecked = false;
        IsGroupsViewChecked = false;
        IsTeachersViewChecked = false;
        IsDisciplinesViewChecked = false;
        switch (CurrentChildView)
        {
            case SpecialtiesView:
            {
                isSpecialtiesViewChecked = true;
                break;
            }
            case GroupsView:
            {
                isGroupsViewChecked = true;
                break;
            }
            case TeachersView:
            {
                isTeachersViewChecked = true;
                break;
            }
            case DisciplinesView:
            {
                isDisciplinesViewChecked = true;
                break;
            }
        }
    }
}