using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

namespace MVVM_WPF_Schedule.Views.Pages.Secretary;

/// <summary>
/// Логика взаимодействия для HomeView.xaml
/// </summary>
public partial class GroupsView : UserControl
{
    public GroupsView()
    {
        InitializeComponent();

        GroupsViewModel viewModel = ViewModelLocator.GroupsViewModel;

        this.DataContext = viewModel;
    }
}

public class BoolToGroupConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool)
        {
            bool isBudget = (bool)value;
            return isBudget ? "Бюджетная" : "Платная";
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}