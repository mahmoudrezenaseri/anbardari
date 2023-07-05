using anbardari.domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anbardari.domain.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbcontext;
        public UserRepository(MyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbcontext.Users.ToListAsync();
        }
    }
}
