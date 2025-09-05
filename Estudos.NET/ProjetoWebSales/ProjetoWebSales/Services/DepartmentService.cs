using Microsoft.EntityFrameworkCore;
using ProjetoWebSales.Models;

namespace ProjetoWebSales.Services
{
    public class DepartmentService
    {
        private readonly ProjetoWebSalesContext _context;

        public DepartmentService(ProjetoWebSalesContext context)
        { _context = context; }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d =>  d.Name).ToList();
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
