using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.MappingProfile
{
    public class LeaveTypeAutoMappingProfile: Profile
    {
        public LeaveTypeAutoMappingProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            CreateMap<LeaveTypeCreateVM, LeaveType>();
            CreateMap<LeaveType, LeaveTypeEditVM>().ReverseMap();
        }
    }   
}
