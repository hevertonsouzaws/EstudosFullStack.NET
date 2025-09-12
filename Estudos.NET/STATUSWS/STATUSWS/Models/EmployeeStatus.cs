using StatusWS.Models.Enums;

namespace StatusWS.Models
{
    public class EmployeeStatus  
    {
        public int Id { get; set; }
        public Enums.StatusType Status { get; set; }
    }
}
