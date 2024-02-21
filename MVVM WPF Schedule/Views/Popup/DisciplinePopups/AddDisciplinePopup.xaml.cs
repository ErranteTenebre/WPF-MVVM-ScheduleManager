using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Popup.DisciplineViewModels;

namespace MVVM_WPF_Schedule.Views.Popup.DisciplinePopups;

public partial class AddDisciplinePopup : Window
{
    private AddDisciplineViewModel _viewModel;

    public AddDisciplinePopup()
    {
        _viewModel = ViewModelLocator.AddDisciplineViewModel;

        this.DataContext = _viewModel;

        _viewModel.OnDestroy += CloseWindow;
        InitializeComponent();
    }

    private void CloseWindow(object? sender, EventArgs e)
    {
        this.DialogResult = _viewModel.DialogResult;

        this.Close();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        this.Close();
    }

}