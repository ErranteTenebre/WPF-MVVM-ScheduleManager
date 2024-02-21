﻿using System.Windows.Controls;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Pages.Main;

namespace MVVM_WPF_Schedule.Views.Pages.Main;

/// <summary>
/// Логика взаимодействия для HomeView.xaml
/// </summary>
public partial class ScheduleTeacher : UserControl
{
    public ScheduleTeacher()
    {
        InitializeComponent();

        ScheduleTeacherViewModel viewModel = ViewModelLocator.ScheduleTeacherViewModel;

        this.DataContext = viewModel;
    }
}
