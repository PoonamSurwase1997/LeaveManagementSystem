using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfile
{
    public class LeaveTypeAutoMappingProfile : Profile
    {
        public LeaveTypeAutoMappingProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            CreateMap<LeaveTypeCreateVM, LeaveType>();
            CreateMap<LeaveType, LeaveTypeEditVM>().ReverseMap();
        }
    }
}
