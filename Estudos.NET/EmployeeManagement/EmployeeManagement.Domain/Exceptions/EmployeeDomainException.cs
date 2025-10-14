namespace EmployeeManagement.Domain.Exceptions;

// Classe base para todas as exceções de domínio
public class EmployeeDomainException : Exception
{
    public EmployeeDomainException() { }

    public EmployeeDomainException(string message)
        : base(message) { }

    public EmployeeDomainException(string message, Exception innerException)
        : base(message, innerException) { }
}