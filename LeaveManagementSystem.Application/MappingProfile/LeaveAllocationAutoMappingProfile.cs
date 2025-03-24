using AutoMapper;

namespace LeaveManagementSystem.Application.MappingProfile
{
    public class LeaveAllocationAutoMappingProfile : Profile
    {
        public LeaveAllocationAutoMappingProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
            CreateMap<ApplicationUser, EmployeeListVM>();
            CreateMap<Period, PeriodVM>();
        }
    }
}
