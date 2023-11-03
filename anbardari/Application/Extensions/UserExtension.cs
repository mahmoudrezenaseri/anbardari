using anbardari.application.ViewModels;
using anbardari.domain.Models;
using System.Collections.Generic;

namespace anbardari.application.Extensions
{
    public static class UserExtension
    {


        public static IEnumerable<UserVm> ToUserVmList(this IEnumerable<User> userItems)
        {
            foreach (User item in userItems)
            {
                yield return item.ToUserVm();
            }
        }

        public static UserVm ToUserVm(this User item)
        {
            return new UserVm
            {
                Id = item.Id,
                UserName = item.UserName,
                FirstName = item.FirstName,
                LastName = item.LastName,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                BirthDate = item.BirthDate,
            };
        }
    }
}
