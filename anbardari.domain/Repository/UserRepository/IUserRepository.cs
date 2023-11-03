using anbardari.domain.Models;

namespace anbardari.domain.Repository.UserRepository
{
    public interface IUserRepository
    {
       public Task<List<User>> GetUsersAsync();
       public Task<List<User>> GetUsersAsync(string name, DateTime? from, DateTime? to);
    }
}