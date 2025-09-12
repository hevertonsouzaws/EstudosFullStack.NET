using System.ComponentModel.DataAnnotations;

namespace StatusWS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        public string? Photo { get; set; }
        public bool IsActive { get; set; } = true;
        public EmployeeStatus Status { get; set; }

    }
}
