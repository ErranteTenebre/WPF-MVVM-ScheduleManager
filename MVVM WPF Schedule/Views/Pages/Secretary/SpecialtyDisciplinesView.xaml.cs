using System.Windows.Controls;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

namespace MVVM_WPF_Schedule.Views.Pages.Secretary
{
    /// <summary>
    /// Логика взаимодействия для SpecialtyDisciplinesView.xaml
    /// </summary>
    public partial class SpecialtyDisciplinesView : UserControl
    {
        private SpecialtyDisciplinesViewModel _viewModel;
        public SpecialtyDisciplinesView(Specialty specialty)
        {
            InitializeComponent();

            _viewModel = ViewModelLocator.SpecialtyDisciplinesViewModel;
            _viewModel.SelectedSpecialty = specialty;

            this.DataContext = _viewModel;
        }
    }
}
