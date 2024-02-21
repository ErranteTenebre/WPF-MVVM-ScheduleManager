using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Popup.GroupViewModels;

namespace MVVM_WPF_Schedule.Views.Popup.Group;

public partial class EditGroupPopup : Window
{
    private EditGroupViewModel _viewModel;

    public EditGroupPopup(Models.Entities.Group group)
    {
        _viewModel = ViewModelLocator.EditGroupViewModel;
        _viewModel.Group = group;

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