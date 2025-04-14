using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lmsapp.Models
{
    public class Dashboard
    {
      public int Id { get; set; } // Primary key
    public string EmployeeId { get; set; }
    public List<LeaveRequest> LeaveHistory { get; set; }
    public List<LeaveBalance> LeaveBalances { get; set; }
    }
}