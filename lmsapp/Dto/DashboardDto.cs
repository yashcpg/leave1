using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lmsapp.Dto
{
    public class DashboardDto
    {
        public string EmployeeId { get; set; }
    public List<LeaveRequestDto> LeaveHistory { get; set; }
    public List<LeaveBalanceDto> LeaveBalances { get; set; }
    }
}