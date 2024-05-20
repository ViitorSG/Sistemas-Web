using AtvOne.Models;
using Microsoft.EntityFrameworkCore;

namespace AtvOne.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
