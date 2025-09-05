using ProjetoWebSales.Models;
using ProjetoWebSales.Models.Enums;


namespace ProjetoWebSales.Data
{
    public class SeedingService
    {
        private ProjetoWebSalesContext _context;

        public SeedingService(ProjetoWebSalesContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
                {
                return;
            }

            Department d1 = new Department("TI");
            Department d2 = new Department("Books");

            Seller s1 = new("Regis Beraldi", "regis.websupply@gmail.com.br", new DateTime(1989, 10, 20), 9000.0, d1);

            SalesRecord r1 = new SalesRecord(new DateTime(2025, 09, 25), 55000.0, SaleStatus.Billed, s1);
          

            // Inclusão no banco com entity

            _context.Department.AddRange(d1, d2);

            _context.Seller.AddRange(s1);

            _context.SalesRecord.AddRange(r1);

            _context.SaveChanges();
        }
    }
}
