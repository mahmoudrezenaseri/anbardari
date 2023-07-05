using anbardari.domain;
using anbardari.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace anbardari
{
    public class LoginWindowViewModel : ObservableObject
    {
        public ObservableCollection<User> Users { get; }

        public LoginWindowViewModel(MyDbContext context)
        {
            context.Users.Load();
            Users = context.Users.Local.ToObservableCollection();
        }

    }
}