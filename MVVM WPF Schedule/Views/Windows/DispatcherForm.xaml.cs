using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Windows;

namespace MVVM_WPF_Schedule.Views.Windows;

/// <summary>
/// Логика взаимодействия для SecretaryForm.xaml
/// </summary>
public partial class DispatcherForm : Window
{
    private DispatcherViewModel _viewModel;
    public DispatcherForm()
    {
        InitializeComponent();

        _viewModel = ViewModelLocator.DispatcherViewModel;

        this.DataContext = _viewModel;

        _viewModel.OnDestroy += viewModel_OnDestroy;
    }

    private void viewModel_OnDestroy(object? sender, EventArgs e)
    {
        this.Close();
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowInteropHelper helper = new WindowInteropHelper(this);
        SendMessage(helper.Handle, 161, 2, 0);
    }
    private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
    {
        this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    }
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Normal)
            this.WindowState = WindowState.Maximized;
        else this.WindowState = WindowState.Normal;
    }
}