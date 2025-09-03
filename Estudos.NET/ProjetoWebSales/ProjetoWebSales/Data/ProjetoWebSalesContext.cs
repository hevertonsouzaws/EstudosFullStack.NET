using Microsoft.EntityFrameworkCore;

namespace ProjetoWebSales.Models
{
    public class ProjetoWebSalesContext : DbContext
    {
        public ProjetoWebSalesContext (DbContextOptions<ProjetoWebSalesContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller{ get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
