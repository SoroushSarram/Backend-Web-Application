using Microsoft.EntityFrameworkCore;
using Soroush_Sarram_2031004_WebServer2.Models;

namespace Soroush_Sarram_2031004_WebServer2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Models.Task> Tasks
        {
            get; set;
        }

        public DbSet<Session> Sessions
        {
            get; set;
        }

        public DbSet<User> Users
        {
            get; set;
        }
    }
}
