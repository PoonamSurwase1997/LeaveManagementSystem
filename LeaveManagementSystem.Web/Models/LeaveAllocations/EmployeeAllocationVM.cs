using System.ComponentModel;
using Microsoft.VisualBasic;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {        

        [DisplayName("Date Birth")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        public bool IsCompletedAllocation {  get; set; }

        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
