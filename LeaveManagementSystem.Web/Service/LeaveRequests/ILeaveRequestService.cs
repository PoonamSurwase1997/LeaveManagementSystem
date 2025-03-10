using LeaveManagementSystem.Web.Models.LeaveRequests;

namespace LeaveManagementSystem.Web.Service.LeaveRequests
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<LeaveRequestListVM> GetAllLeaveRequests();
        Task CancelLeaveRequest(int  leaveRequestId);
        Task ReviewLeaveRequest(int leaveRequestId, bool approved);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
        Task<EmployeeLeaveRequestListVM> AdminGeteaveRequests();
        Task<ReviewLeaveRequesVM> GetLeaveRequestForReview(int id);
    }
}