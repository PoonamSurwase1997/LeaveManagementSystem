using System.ComponentModel;
using LeaveManagementSystem.Web.Service.LeaveRequests;

namespace LeaveManagementSystem.Web.Models.LeaveRequests
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
