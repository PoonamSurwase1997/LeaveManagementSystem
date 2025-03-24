using AutoMapper;

public class LeaveRequestsAutoMappingProfile : Profile
{
    public LeaveRequestsAutoMappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestCreateVM>();
        CreateMap<LeaveRequestCreateVM, LeaveRequest>();
    }

}