namespace EmployeeManagement.Domain.ValueObjects;

public class ProfilePictureUrl
{
    public string Url { get; private set; }

    public const string DEFAULT_URL = "https://tarefas.websupply.com.br/painel/assets/userDefault-uMDAqLiz.png";

    private ProfilePictureUrl(string url)
    {
        Url = url;
    }

    public static ProfilePictureUrl Create(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return new ProfilePictureUrl(DEFAULT_URL);
        }

        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            throw new ArgumentException("A URL da imagem de perfil fornecida é inválida.", nameof(url));
        }

        return new ProfilePictureUrl(url);
    }

    public override string ToString() => Url;
}