namespace Remaza.Api.Dtos
{
    public class CheckInResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string VisitPurpose { get; set; } = string.Empty;
        public int VisitCount { get; set; }
        public string CheckInTime { get; set; } = string.Empty;
        public string CredentialId { get; set; } = string.Empty;
        public string? ServicePassword { get; set; }
        public string? WifiToken { get; set; }
    }
}
