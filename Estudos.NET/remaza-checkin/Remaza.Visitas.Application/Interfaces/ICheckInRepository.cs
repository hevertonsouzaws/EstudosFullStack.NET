using Remaza.Visitas.Domain.Entities;
using System.Threading.Tasks;

namespace Remaza.Visitas.Application.Interfaces
{
    public interface ICheckInRepository
    {
        Task AddAsync(CheckIn checkIn);
        Task UpdateAsync(CheckIn checkIn);
    }
}