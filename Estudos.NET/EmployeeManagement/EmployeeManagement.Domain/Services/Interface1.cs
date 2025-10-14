using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Services;

// Define o contrato para verificar se um funcionário com determinado email já existe.
public interface IEmployeeUniquenessChecker
{
    // A checagem é assíncrona porque acessa o banco de dados (Infraestrutura)
    Task<bool> IsEmailUniqueAsync(Email email);
}