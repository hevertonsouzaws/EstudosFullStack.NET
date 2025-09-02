using Microsoft.EntityFrameworkCore;
using AulaBaltaApi.Models; 

namespace AulaBaltaApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}