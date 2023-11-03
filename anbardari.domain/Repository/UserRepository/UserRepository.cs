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

        public async Task<List<User>> GetUsersAsync(string name, DateTime? from, DateTime? to)
        {
            IQueryable<User> query = _dbcontext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FirstName.Contains(name) || a.LastName.Contains(name));
            }

            if (from is not null)
            {
                query = query.Where(a => a.CreateAt >= from);
            }

            if (from is not null)
            {
                query = query.Where(a => a.CreateAt <= to);
            }

            int currentPage = 1;
            int pageSize = 10;
            int skip = (currentPage - 1) * pageSize;
            List<User> result = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
