namespace Remaza.Visitas.Api.Dtos
{
    public class VisitorSummaryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string VisitPurpose { get; set; } = string.Empty;
        public string LastVisit { get; set; } = string.Empty;
    }
}
