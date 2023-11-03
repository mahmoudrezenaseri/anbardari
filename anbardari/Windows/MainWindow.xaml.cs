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

namespace anbardari.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UsersWindows _usersWindows;

        public MainWindow(UsersWindows usersWindows)
        {
            InitializeComponent();
            this._usersWindows = usersWindows;
        }

        private void Aboutus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This project is a simple data application that uses WPF, C#, .NET 6, and SQL Server with a code-first approach.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Contactus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Support Email: Support@anbardari.com");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MinHeight = 650;
            MaxHeight = 650;
            MinWidth = 1200;
            MaxWidth = 1200;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            _usersWindows.Show();
        }
    }
}
