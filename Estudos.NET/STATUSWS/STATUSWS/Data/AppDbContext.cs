using Microsoft.EntityFrameworkCore;
using StatusWS.Models;

namespace StatusWS.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    }
}
