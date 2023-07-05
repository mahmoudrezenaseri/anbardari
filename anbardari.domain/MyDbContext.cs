using anbardari.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace anbardari.domain
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
       : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}