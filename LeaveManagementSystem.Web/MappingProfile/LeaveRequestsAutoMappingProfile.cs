using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveRequests;
using LeaveManagementSystem.Web.Models.LeaveType;

public class LeaveRequestsAutoMappingProfile : Profile
{
    public LeaveRequestsAutoMappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestCreateVM>();
        CreateMap<LeaveRequestCreateVM, LeaveRequest>();
    }

}