using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Infrastructure.Services;

// Implementa a Interface do Domínio (IEmployeeUniquenessChecker)
public class EmployeeUniquenessChecker : IEmployeeUniquenessChecker
{
    // Injetamos o Repositório para fazer a busca no banco
    private readonly IEmployeeRepository _repository;

    public EmployeeUniquenessChecker(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> IsEmailUniqueAsync(Email email)
    {
        var employee = await _repository.GetByEmailAsync(email);

        // Se a busca retornar NULL, significa que o email é único (TRUE)
        return employee == null;
    }
}