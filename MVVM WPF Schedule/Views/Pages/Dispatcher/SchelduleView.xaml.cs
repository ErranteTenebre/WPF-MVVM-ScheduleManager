using System.Windows.Controls;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Pages.Dispatcher;

namespace MVVM_WPF_Schedule.Views.Pages.Dispatcher;

/// <summary>
/// Логика взаимодействия для HomeView.xaml
/// </summary>
public partial class ScheduleView : UserControl
{
    public ScheduleView()
    {
        InitializeComponent();

        ScheduleViewModel viewModel = ViewModelLocator.ScheduleViewModel;

        this.DataContext = viewModel;
    }
}
