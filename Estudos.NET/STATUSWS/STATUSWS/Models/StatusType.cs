using System.ComponentModel.DataAnnotations;

namespace StatusWS.Models
{
    public class StatusType
    {
        [Key]
        public int StatusTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        public string IconUrl { get; set; } = "https://cdn-icons-png.flaticon.com/512/4785/4785876.png";
    }
}
