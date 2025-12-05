using Microsoft.EntityFrameworkCore;
using MyCvSite.Models;

namespace MyCvSite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
    }
}
