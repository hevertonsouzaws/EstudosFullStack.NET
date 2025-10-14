using MediatR;
using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Commands;

// O Command representa uma intenção de escrita (alteração de estado)
// IRequest<EmployeeOutputModel> diz que este comando espera retornar um EmployeeOutputModel após a execução
public class HireEmployeeCommand : IRequest<EmployeeOutputModel>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string? ImageUrl { get; set; }
}