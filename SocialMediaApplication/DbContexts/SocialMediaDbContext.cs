using Microsoft.EntityFrameworkCore;
using SocialMediaApplication.Models;

namespace SocialMediaApplication.DbContexts
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<TaggedUsers> taggedUsers { get; set; }

    }
}
