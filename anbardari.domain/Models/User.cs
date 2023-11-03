using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace anbardari.domain.Models
{
    public class User : IdentityUser<int>
    {
        public User(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? BirthDate { get; set; }
        public string? About { get; set; }

        public DateTime? CreateAt { get; }
        public DateTime? ModifiedAt { get; }

        public string FullName
        {
            get
            {
                return string.Concat(FirstName," ", LastName);
            }
        }
    }
}