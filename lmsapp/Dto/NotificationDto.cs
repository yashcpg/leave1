using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lmsapp.Models;

namespace lmsapp.Dto
{
    public class NotificationDto
    {
        public string EmployeeId { get; set; }
    public string ManagerId { get; set; }
    public NotificationType Type { get; set; }
    public string Message { get; set; }
    }
}