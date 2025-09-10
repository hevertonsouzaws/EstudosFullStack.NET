namespace DashboardWS.Models
{
    public class Status
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string StatusType { get; set; }
        public string CustomText { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
