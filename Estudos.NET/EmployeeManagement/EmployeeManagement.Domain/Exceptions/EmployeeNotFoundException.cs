namespace EmployeeManagement.Domain.Exceptions;

public class EmployeeNotFoundException : EmployeeDomainException
{
    public EmployeeNotFoundException(Guid employeeId)
        : base($"Funcionário com ID '{employeeId}' não foi encontrado.") { }
}