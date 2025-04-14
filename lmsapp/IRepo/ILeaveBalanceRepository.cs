using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lmsapp.Models;

namespace lmsapp.IRepo
{
    public interface ILeaveBalanceRepository
    {
         Task<LeaveBalance> GetLeaveBalanceAsync(string employeeId, LeaveType leaveType);
        Task UpdateLeaveBalanceAsync(LeaveBalance leaveBalance);
    }
}