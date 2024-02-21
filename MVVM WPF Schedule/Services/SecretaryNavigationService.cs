using System.Windows.Controls;
using FontAwesome.Sharp;
using MVVM_WPF_Schedule.Views.Pages;
using MVVM_WPF_Schedule.Views.Pages.Secretary;

namespace MVVM_WPF_Schedule.Services
{
    public class SecretaryNavigationService
    {
        public event EventHandler CurrentViewChanged;

        private UserControl _currentChildView = new HomeView();
        private IconChar _icon;
        private string _caption;

        private bool isHomeViewChecked = false;
        private bool isSpecialtiesViewChecked = false;
        private bool isGroupsViewChecked = false;
        private bool isTeachersViewChecked = false;
        private bool isDisciplinesViewChecked = false;

        public UserControl CurrentChildView
        {
            get { return _currentChildView; }
            set
            {
                _currentChildView = value;
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
            }
        }

        public bool IsHomeViewChecked
        {
            get { return isHomeViewChecked; }
            set
            {
                isHomeViewChecked = value;
                
            }
        }

        public bool IsSpecialtiesViewChecked
        {
            get { return isSpecialtiesViewChecked; }
            set
            {
                isSpecialtiesViewChecked = value;
            }
        }

        public bool IsGroupsViewChecked
        {
            get { return isGroupsViewChecked; }
            set
            {
                isGroupsViewChecked = value;
            }
        }

        public bool IsDisciplinesViewChecked
        {
            get { return isDisciplinesViewChecked; }
            set
            {
                isDisciplinesViewChecked = value;
            }
        }

        public bool IsTeachersViewChecked
        {
            get { return isTeachersViewChecked; }
            set
            {
                isTeachersViewChecked = value;
            }
        }

        public void ChangeCurrentChildView(UserControl newView, string caption, IconChar icon)
        {
            CurrentChildView = newView;
            Caption = caption;
            Icon = icon;
            ChangeNavigationChecked();
            CurrentViewChanged.Invoke(this, EventArgs.Empty);
        }

        private void ChangeNavigationChecked()
        {
            IsHomeViewChecked = false;
            IsSpecialtiesViewChecked = false;
            IsGroupsViewChecked = false;
            IsTeachersViewChecked = false;
            IsDisciplinesViewChecked = false;
            switch (CurrentChildView)
            {
                case HomeView:
                {
                    IsHomeViewChecked = true;
                    break;
                }
                case SpecialtiesView:
                {
                    isSpecialtiesViewChecked = true;
                    break;
                }
                case GroupsView:
                {
                    isGroupsViewChecked = true;
                    break;
                }
                case TeachersView:
                {
                    isTeachersViewChecked = true;
                    break;
                }
                case DisciplinesView:
                {
                    isDisciplinesViewChecked = true;
                    break;
                }
            }
        }
    }
}
