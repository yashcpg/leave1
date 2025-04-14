using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lmsapp.IRepo
{
    public interface ILeaveRequestRepository
    {
        Task<LeaveRequest> GetLeaveRequestByIdAsync(int id);
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByEmployeeIdAsync(string employeeId);
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByManagerIdAsync(string managerId);
        Task AddLeaveRequestAsync(LeaveRequest leaveRequest);
        Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        
    }
}