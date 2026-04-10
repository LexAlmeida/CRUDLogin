using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Models.User> login { get; set; }
    }
}