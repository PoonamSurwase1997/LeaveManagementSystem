using LeaveManagementSystem.Web.Models.LeaveAllocations;

namespace LeaveManagementSystem.Web.Models.LeaveRequests
{
    public class ReviewLeaveRequesVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();
        public string RequestComments { get; set; }
    }
}