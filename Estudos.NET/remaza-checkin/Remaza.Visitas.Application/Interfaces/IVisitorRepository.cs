using Remaza.Visitas.Domain.Entities;
using Remaza.Visitas.Dtos; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Remaza.Visitas.Application.Interfaces
{
    public interface IVisitorRepository
    {
        Task<Visitor?> GetByDocumentAsync(string document);
        Task<List<Visitor>> GetAllAsync(); 
        Task AddAsync(Visitor visitor);
        Task UpdateAsync(Visitor visitor);
        Task<List<Visitor>> SearchVisitorsAsync(string searchTerm);
        Task<List<CheckIn>> GetAllCheckInsAsync();
        Task<List<CheckIn>> GetRecentCheckInsAsync(int count);
        Task<DailyStatsDto> GetDailyCheckInStatsAsync(); 
        Task<int> SaveChangesAsync();
    }
}
