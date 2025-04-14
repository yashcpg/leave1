using lmsapp.Dto;
using lmsapp.IRepo;
using lmsapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace lmsapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")] // Only employees can apply for leave
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForLeave([FromBody] CreateLeaveRequestDto requestDto)
        {
            // Get employee ID from token
            var employeeId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(employeeId))
                return Unauthorized("Invalid token: Employee ID not found.");

            // Prevent applying for past dates
            if (requestDto.StartDate.Date < DateTime.UtcNow.Date)
                return BadRequest("Cannot apply for past dates.");

            var leaveRequest = new LeaveRequest
            {
                EmployeeId = employeeId,
                LeaveType = requestDto.LeaveType,
                StartDate = requestDto.StartDate,
                EndDate = requestDto.EndDate,
                Reason = requestDto.Reason,
                Status = LeaveStatus.Pending,
                DateRequested = DateTime.UtcNow
            };

            await _leaveRequestRepository.AddLeaveRequestAsync(leaveRequest);
            return Ok(new { message = "Leave request submitted successfully." });
        }
    

        // Manager approves or rejects leave request
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveLeaveRequest(int id, [FromBody] bool isApproved)
        {
            var leaveRequest = await _leaveRequestRepo.GetLeaveRequestByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound("Leave request not found.");
            }

            if (isApproved)
            {
                // Approve leave and update leave balance
                var leaveBalance = await _leaveBalanceRepo.GetLeaveBalanceAsync(leaveRequest.EmployeeId, leaveRequest.LeaveType);
                if (leaveBalance != null && leaveBalance.RemainingDays > 0)
                {
                    leaveBalance.RemainingDays -= (leaveRequest.EndDate - leaveRequest.StartDate).Days;
                    await _leaveBalanceRepo.UpdateLeaveBalanceAsync(leaveBalance);
                    leaveRequest.Status = LeaveStatus.Approved;
                }
                else
                {
                    return BadRequest("Insufficient leave balance.");
                }
            }
            else
            {
                leaveRequest.Status = LeaveStatus.Rejected;
            }

            await _leaveRequestRepo.UpdateLeaveRequestAsync(leaveRequest);
            return Ok(new { Message = "Leave request updated." });
        }
    }
}
