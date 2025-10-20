namespace Remaza.Visitas.Dtos
{
    public class CheckInRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string VisitPurpose { get; set; } = string.Empty;
    }
}
