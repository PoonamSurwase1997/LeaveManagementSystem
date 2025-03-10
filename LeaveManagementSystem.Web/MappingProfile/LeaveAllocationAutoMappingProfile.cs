using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Models.Periods;

namespace LeaveManagementSystem.Web.MappingProfile
{
    public class LeaveAllocationAutoMappingProfile :Profile
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
