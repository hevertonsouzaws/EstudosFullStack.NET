using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardWS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Position { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[]? Photo { get; set; }
    }
}
