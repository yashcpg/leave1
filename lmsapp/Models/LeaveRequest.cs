using lmsapp.Models;

public class LeaveRequest
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } // Use string for text data
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; } // Use string for text data
    public LeaveStatus Status { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime? DateActioned { get; set; }
    public string ManagerId { get; set; } // Use string for text data


    public bool IsValidRequest(){
        return StartDate >= DateTime.Now && EndDate >= StartDate;
    }
}