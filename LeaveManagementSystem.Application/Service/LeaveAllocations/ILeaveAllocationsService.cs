using LeaveManagementSystem.Application.Models.LeaveAllocations;

namespace LeaveManagementSystem.Application.Service.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeId);
        Task<List<EmployeeListVM>> GetAllEmployees();
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId);
        Task EditAllocation(LeaveAllocationEditVM leaveAllocationEditVM);
        Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId);
    }
}
