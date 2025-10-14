using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Repositories;

public interface IEmployeeRepository
{
    // Adicionar um novo funcionário (Employee é o Aggregate Root)
    Task AddAsync(Employee employee);

    // Buscar por ID é essencial para qualquer Aggregate Root
    Task<Employee?> GetByIdAsync(Guid id);

    // Buscar por um Value Object importante (garantindo que o email é único)
    Task<Employee?> GetByEmailAsync(Email email);

    // Atualizar. No EF Core, isso é apenas SaveChanges, mas a intenção deve estar aqui
    Task UpdateAsync(Employee employee);

    // Simplesmente buscar todos para um caso de uso de listagem
    Task<IEnumerable<Employee>> GetAllAsync();
}