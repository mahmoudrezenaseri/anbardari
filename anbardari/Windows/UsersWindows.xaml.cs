using anbardari.application.Extensions;
using anbardari.domain.Models;
using anbardari.domain.Repository.UserRepository;
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
    /// Interaction logic for UsersWindows.xaml
    /// </summary>
    public partial class UsersWindows : Window
    {
        private readonly IUserRepository _userRepository;

        public UsersWindows(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MinHeight = 650;
            MaxHeight = 650;
            MinWidth = 1200;
            MaxWidth = 1200;

            List<User> users = await _userRepository.GetUsersAsync();
            UserGrid.ItemsSource = users.ToUserVmList();
        }

        private void GridView_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fromDate = DateFrom.SelectedDate;
            DateTime? toDate = DateTo.SelectedDate;
            List<User> users = await _userRepository.GetUsersAsync(txtName.Text, fromDate,toDate);
            UserGrid.ItemsSource = users.ToUserVmList();
        }
    }
}
