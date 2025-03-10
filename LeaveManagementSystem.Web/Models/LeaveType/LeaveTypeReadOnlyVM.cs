using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Models.LeaveType
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        [Column(TypeName = "nvarchar(150)")]
        //[MaxLength(150)]
        public string Name { get; set; } =string.Empty;

        [DisplayName("Maximum allocation of days")]
        public int NumberOfDays { get; set; }
    }


}
