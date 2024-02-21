using System.Windows.Controls;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

namespace MVVM_WPF_Schedule.Views.Pages.Secretary;

/// <summary>
/// Логика взаимодействия для HomeView.xaml
/// </summary>
public partial class SpecialtiesView : UserControl
{
    public SpecialtiesView()
    {
        InitializeComponent();

        SpecialtiesViewModel viewModel = ViewModelLocator.SpecialtiesViewModel;

        this.DataContext = viewModel;
    }
}