namespace EmployeeManagement.Domain.ValueObjects;

public class Email
{
    public string Address { get; private set; }

    private Email(string address)
    {
        Address = address;
    }

    public static Email Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValidEmail(address))
        {
            throw new ArgumentException("O endereço de e-mail fornecido é inválido.", nameof(address));
        }

        return new Email(address);
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public override string ToString() => Address;
}