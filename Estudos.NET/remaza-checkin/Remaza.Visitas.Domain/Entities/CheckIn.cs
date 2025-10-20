// Remaza.Visitas.Domain.Entities/CheckIn.cs

using System;

namespace Remaza.Visitas.Domain.Entities
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public DateTimeOffset CheckInTime { get; set; }
        public string Type { get; set; } = string.Empty;
        public string VisitPurpose { get; set; } = string.Empty;
        public Visitor Visitor { get; set; } = null!;
        public string? ServicePassword { get; set; }
        public string? WifiToken { get; set; }
        public DateTimeOffset? WifiTokenExpiresAt { get; set; }
    }
}