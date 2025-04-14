using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lmsapp.Models;
using lmsapp.IRepo;

namespace lmsapp.Repo
{
    public class LeaveBalanceRepository : ILeaveBalanceRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveBalanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaveBalance> GetLeaveBalanceAsync(string employeeId, LeaveType leaveType)
        {
            return await _context.LeaveBalances
                .FirstOrDefaultAsync(lb => lb.EmployeeId == employeeId && lb.LeaveType == leaveType);
        }

        public async Task UpdateLeaveBalanceAsync(LeaveBalance leaveBalance)
        {
            _context.LeaveBalances.Update(leaveBalance);
            await _context.SaveChangesAsync();
        }
    }
}