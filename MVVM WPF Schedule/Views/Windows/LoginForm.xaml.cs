using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Windows;

namespace MVVM_WPF_Schedule.Views.Windows;

public partial class LoginForm : Window
{
    private LoginViewModel _viewModel;
    public LoginForm()
    {
        InitializeComponent();

        _viewModel = ViewModelLocator.LogInViewModel;

        this.DataContext = _viewModel;

        _viewModel.OnDestroy += ViewModel_OnDestroy;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

    private void ViewModel_OnDestroy(object sender, EventArgs e)
    {
        DialogResult = true;
        this.Close();
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