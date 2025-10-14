using EmployeeManagement.Application.Commands;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.ValueObjects;
using MediatR;

namespace EmployeeManagement.Application.Handlers;

public class HireEmployeeHandler : IRequestHandler<HireEmployeeCommand, EmployeeOutputModel>
{
    private readonly IEmployeeRepository _repository;
    private readonly IEmployeeUniquenessChecker _uniquenessChecker; 

    public HireEmployeeHandler(IEmployeeRepository repository, IEmployeeUniquenessChecker uniquenessChecker)
    {
        _repository = repository;
        _uniquenessChecker = uniquenessChecker; 
    }

    public async Task<EmployeeOutputModel> Handle(HireEmployeeCommand request, CancellationToken cancellationToken)
    {
        // 1. Validação de Unicidade (Regra de Negócio Inter-Agregado)
        var emailVo = Email.Create(request.Email);

        if (!await _uniquenessChecker.IsEmailUniqueAsync(emailVo))
        {
            // MENSAGEM EM PORTUGUÊS
            throw new ArgumentException("Já existe um funcionário cadastrado com este e-mail.", nameof(request.Email));
        }

        // 2. Criação da Entidade (Regra de Negócio de Agregado)
        var newEmployee = Employee.Hire(
            request.Name,
            request.Email,
            request.ImageUrl
        );

        // 3. Persistência
        await _repository.AddAsync(newEmployee);

        // 4. Mapeamento para DTO
        var output = new EmployeeOutputModel
        {
            Id = newEmployee.Id,
            Name = newEmployee.Name,
            Email = newEmployee.Email.Address,
            ProfilePictureUrl = newEmployee.ProfilePicture.Url
        };

        return output;
    }
}