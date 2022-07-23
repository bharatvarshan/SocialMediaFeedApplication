using Microsoft.EntityFrameworkCore;
using SocialMediaApplication.Models;

namespace SocialMediaApplication.DbContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feed> Feeds { get; set; }

    }
}
