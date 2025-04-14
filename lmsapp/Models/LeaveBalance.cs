namespace lmsapp.Models
{
    public class LeaveBalance
    {
       public int Id { get; set; }
    public string EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public int TotalDays { get; set; }
    public int RemainingDays { get; set; }
    }
}