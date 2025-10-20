using Microsoft.EntityFrameworkCore;
using Remaza.Visitas.Application.Interfaces;
using Remaza.Visitas.Domain.Entities;
using Remaza.Visitas.Infrastructure.Data;
using Remaza.Visitas.Dtos; // Necessário para DailyStatsDto

namespace Remaza.Visitas.Infrastructure.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- Métodos de CRUD Básico e Visitor ---

        public async Task<Visitor?> GetByDocumentAsync(string document)
        {
            // O tipo de retorno na interface era Task<Visitor?>, corrigindo aqui para retornar o tipo correto.
            return await _context.Visitors
                .FirstOrDefaultAsync(v => v.Document == document);
        }

        public async Task<List<Visitor>> GetAllAsync()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task AddAsync(Visitor visitor)
        {
            _context.Visitors.Add(visitor);
            // Removendo Task.CompletedTask desnecessário, o SaveChanges fará o trabalho.
        }

        public async Task UpdateAsync(Visitor visitor)
        {
            _context.Visitors.Update(visitor);
            // Removendo Task.CompletedTask desnecessário.
        }

        public async Task<List<Visitor>> SearchVisitorsAsync(string query)
        {
            return await _context.Visitors
                .Where(v => v.Name.Contains(query) || v.Document.Contains(query))
                .ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CheckIn>> GetAllCheckInsAsync()
        {
            return await _context.CheckIns
                .Include(c => c.Visitor)
                .OrderByDescending(c => c.CheckInTime) 
                .ToListAsync();
        }

        public async Task<List<CheckIn>> GetRecentCheckInsAsync(int count)
        {
            return await _context.CheckIns
                .Include(c => c.Visitor)
                .OrderByDescending(c => c.CheckInTime)
                .Take(count)
                .ToListAsync();
        }

        public async Task<DailyStatsDto> GetDailyCheckInStatsAsync()
        {
            var today = DateTime.UtcNow.Date; 

            var checkInsToday = await _context.CheckIns
                .Where(c => c.CheckInTime.Date == today)
                .ToListAsync();

            var stats = new DailyStatsDto
            {
                Total = checkInsToday.Count,
                ByType = checkInsToday.GroupBy(c => c.Type)
                                      .ToDictionary(g => g.Key, g => g.Count()),
                Date = today.ToString("yyyy-MM-dd")
            };

            return stats;
        }
    }
}