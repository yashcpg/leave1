using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lmsapp.Models
{
    public class Notification
    {
        public int Id { get; set; }
    public string EmployeeId { get; set; }
    public string ManagerId { get; set; }
    public NotificationType Type { get; set; }
    public string Message { get; set; }
    public DateTime DateSent { get; set; }
    }
}