using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lmsapp.Models;

namespace lmsapp.Dto
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
    public string EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public LeaveStatus Status { get; set; }
    }
}