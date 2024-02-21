using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Popup.Specialty;

namespace MVVM_WPF_Schedule.Views.Popup.SpecialtyPopup;

public partial class EditSpecialtyPopup : Window
{
    private EditSpecialtyViewModel _viewModel;

    public EditSpecialtyPopup(Specialty specialty)
    {
        _viewModel = ViewModelLocator.EditSpecialtyViewModel;
        _viewModel.Specialty = specialty;

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