using System.ComponentModel;
using LeaveManagementSystem.Application.Service.LeaveRequests;

namespace LeaveManagementSystem.Application.Models.LeaveRequests
{
    public class LeaveRequestReadOnlyVM : BaseEntity
    {
        [DisplayName("Start Date")]
        public DateOnly StartDate { get; set; }

        [DisplayName("End Date")]
        public DateOnly EndDate { get; set; }

        [DisplayName("Total Days")]
        public int NumberOfDays { get; set; }

        [DisplayName("Leave Type")]
        public string LeaveType { get; set; } = string.Empty;

        [DisplayName("Status")]
        public LeaveRequestStatusEnum LeaveRequestStatusEnum { get; set; }
    }
}
