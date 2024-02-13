using CursachApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CursachApp.Views
{
    /// <summary>
    /// Логика взаимодействия для SecretaryForm.xaml
    /// </summary>
    public partial class SecretaryForm : Window
    {
        private CurrentUser _curUser;
        public SecretaryForm()
        {
            _curUser = CurrentUser.GetSingletone();
            InitializeComponent();

            txtWelcome.Text = "Добро пожаловать\n" + _curUser.FIO;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
