namespace EmployeeManagement.Application.DTOs;

public class EmployeeOutputModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ProfilePictureUrl { get; set; }
}