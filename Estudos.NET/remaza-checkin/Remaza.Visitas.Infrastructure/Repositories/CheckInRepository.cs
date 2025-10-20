using Remaza.Visitas.Application.Interfaces;
using Remaza.Visitas.Domain.Entities;
using Remaza.Visitas.Infrastructure.Data;
using System.Threading.Tasks;

namespace Remaza.Visitas.Infrastructure.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly ApplicationDbContext _context;

        public CheckInRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CheckIn checkIn)
        {
            _context.CheckIns.Add(checkIn);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(CheckIn checkIn)
        {
            _context.CheckIns.Update(checkIn);
            await Task.CompletedTask;
        }
    }
}