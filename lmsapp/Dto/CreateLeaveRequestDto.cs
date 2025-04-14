using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lmsapp.Dto
{
    public class CreateLeaveRequestDto
    {
        public string EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
     public string ManagerId { get; set; } // Use string for text data
    }
}