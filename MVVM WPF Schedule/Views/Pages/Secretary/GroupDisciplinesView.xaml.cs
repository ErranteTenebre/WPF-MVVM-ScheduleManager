using System.Windows.Controls;
using MVVM_WPF_Schedule.Models.Entities;
using MVVM_WPF_Schedule.ViewModels.Base;
using MVVM_WPF_Schedule.ViewModels.Pages.Secretary;

namespace MVVM_WPF_Schedule.Views.Pages.Secretary
{
    /// <summary>
    /// Логика взаимодействия для SpecialtyDisciplinesView.xaml
    /// </summary>
    public partial class GroupDisciplinesView : UserControl
    {
        private GroupDisciplinesViewModel _viewModel;
        public GroupDisciplinesView(Group group)
        {
            InitializeComponent();

            _viewModel = ViewModelLocator.GroupDisciplinesViewModel;
            _viewModel.Group = group;

            this.DataContext = _viewModel;
        }
    }
}
