using EmployeeManagement.Domain.ValueObjects;

namespace EmployeeManagement.Domain.Entities;

// Entity (Entidade) e Aggregate Root (Raiz do Agregado)
public class Employee
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    // O agregado usa os Value Objects
    public Email Email { get; private set; }
    public ProfilePictureUrl ProfilePicture { get; private set; }

    // Construtor PROTEGIDO: Usado pelo Entity Framework Core e impede criação direta
    protected Employee() { }

    // Construtor PRIVADO: Usado apenas pelo método de fábrica 'Hire'
    private Employee(string name, Email email, ProfilePictureUrl profilePicture)
    {
        // Validação de Entidade: Nome não pode ser vazio
        if (string.IsNullOrWhiteSpace(name))
        {
            // MENSAGEM EM PORTUGUÊS
            throw new ArgumentException("O nome do funcionário não pode ser vazio.", nameof(name));
        }

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        ProfilePicture = profilePicture;
    }

    // Método de Fábrica (Ponto de entrada para criar um novo agregado)
    public static Employee Hire(string name, string email, string? imageUrl)
    {
        // A validação ocorre DENTRO dos Value Objects
        var emailVo = Email.Create(email);
        var imageVo = ProfilePictureUrl.Create(imageUrl);

        return new Employee(name, emailVo, imageVo);
    }

    // MÉTODOS DE COMPORTAMENTO (Regras de Negócio)
    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("O novo nome não pode ser vazio.", nameof(newName));
        }
        Name = newName;
    }
}