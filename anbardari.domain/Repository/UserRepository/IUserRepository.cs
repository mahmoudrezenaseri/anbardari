using anbardari.domain.Models;

namespace anbardari.domain.Repository.UserRepository
{
    public interface IUserRepository
    {
       public Task<List<User>> GetUsersAsync();
    }
}