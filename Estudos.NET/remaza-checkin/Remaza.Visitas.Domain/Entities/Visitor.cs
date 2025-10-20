// Remaza.Visitas.Domain.Entities/Visitor.cs

using System;
using System.Collections.Generic;

namespace Remaza.Visitas.Domain.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;

        public int VisitCount { get; set; } = 0; 
        public DateTimeOffset LastVisit { get; set; } 
        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

    }
}