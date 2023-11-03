using anbardari.domain.Repository.UserRepository;
using anbardari.Windows;
using MaterialDesignThemes.Wpf;
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

namespace anbardari
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserRepository _userRepository;
        private readonly MainWindow _mainWindow;
        private readonly PaletteHelper paletteHelper = new ();
        private bool IsDarkTheme { get; set; }


        public LoginWindow(IUserRepository userRepository, MainWindow mainWindow)
        {
            InitializeComponent();

            _userRepository = userRepository;
            _mainWindow = mainWindow;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please check Username!");
                return;
            }

            string correctPassword = "admin1234";
            if (string.IsNullOrEmpty(txtPassword.Password) || txtPassword.Password != correctPassword)
            {
                MessageBox.Show("Please check Password!");
                return;
            }

            if (txtUsername.Text == "admin" && txtPassword.Password == correctPassword)
            {
                _mainWindow.Show();
            }
        }
    }
}
