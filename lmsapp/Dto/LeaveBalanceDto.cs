using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lmsapp.Dto
{
    public class LeaveBalanceDto
    {
        public string EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public int TotalDays { get; set; }
    public int RemainingDays { get; set; }
    }
}