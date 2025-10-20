using Microsoft.EntityFrameworkCore;
using Remaza.Visitas.Domain.Entities;

namespace Remaza.Visitas.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Visitor> Visitors { get; set; } = default!;
        public DbSet<CheckIn> CheckIns { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>()
                .HasIndex(v => v.Document)
                .IsUnique();
        }
    }
}