using System.Windows;
using System.Windows.Input;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Popup.SpecialtyDisciplineViewModels;

namespace MVVM_WPF_Schedule.Views.Popup.SpecialtyDisciplinePopups;

public partial class EditSpecialtyDisciplinePopup : Window
{
    private EditSpecialtyDisciplineViewModel _viewModel;

    public EditSpecialtyDisciplinePopup(SpecialtyDiscipline specialtyDiscipline)
    {
        _viewModel = ViewModelLocator.EditSpecialtyDisciplineViewModel;
        _viewModel.SpecialtyDiscipline = specialtyDiscipline;

        this.DataContext = _viewModel;

        _viewModel.OnDestroy += CloseWindow;
        InitializeComponent();
    }

    private void CloseWindow(object? sender, EventArgs e)
    {
        DialogResult = true;

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