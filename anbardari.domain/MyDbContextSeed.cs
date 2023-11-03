using anbardari.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace anbardari.domain
{
    public class MyDbContextSeed
    {
        public static async Task SeedAsync(MyDbContext dbContext, ILogger<MyDbContextSeed> logger)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.AddRange(GetPreconfiguredUsers());
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(MyDbContext).Name);
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            List<User> scList = new()
            {
                new User("michael", "jackson","michael@gmail.com", "+33633654015"),
                new User("george", "michael", "george@gmail.com", "+33454654120"),
                new User("elton", "john", "elton@gmail.com", "+33443654876"),
            };

            return scList;
        }
    }
}