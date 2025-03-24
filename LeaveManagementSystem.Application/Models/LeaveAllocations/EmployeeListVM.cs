using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveAllocations
{
    public class EmployeeListVM
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
