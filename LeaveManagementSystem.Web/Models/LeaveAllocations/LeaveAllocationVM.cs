using System.ComponentModel;
using LeaveManagementSystem.Web.Models.LeaveType;
using LeaveManagementSystem.Web.Models.Periods;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }
        [DisplayName("Number of days")]
        public int Days { get; set; }
        [DisplayName("Allocation Period")]
        public PeriodVM Period { get; set; } = new PeriodVM();
        public LeaveTypeReadOnlyVM LeaveType { get; set; } = new LeaveTypeReadOnlyVM();

    }
}
