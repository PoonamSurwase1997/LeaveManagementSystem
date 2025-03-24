
using AutoMapper;
using LeaveManagementSystem.Application.Service.Periods;
using LeaveManagementSystem.Application.Service.Users;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Service.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IUserServices _userServices, IMapper _mapper, IPeriodService _periodsService) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeId)
        {
            var leaveTypes = await _context.LeaveTypes.Where(p => !p.LeaveAllocations.Any(a => a.EmployeeId == employeId)).ToListAsync();

            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleOrDefaultAsync(p => p.EndDate.Year == currentDate.Year);

            if (period == null)
                throw new Exception("No period found, Please check period");

            var monthRemaining = period.EndDate.Month - currentDate.Month;

            foreach (var leaveType in leaveTypes)
            {
                var accurateRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accurateRate * monthRemaining)
                };
                _context.LeaveAllocations.Add(leaveAllocation);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrWhiteSpace(userId)
                ? await _userServices.GetLoggedUser()
                : await _userServices.GetUserById(userId);

            var allocations = await GetAllocationLeave(user.Id);
            var allocationsVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var leaveType = _context.LeaveTypes.Count();

            var employeeVm = new EmployeeAllocationVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.BirthDate,
                Email = user.Email,
                LeaveAllocations = allocationsVmList,
                IsCompletedAllocation = allocations.Count == leaveType
            };

            return employeeVm;
        }

        public async Task<List<EmployeeListVM>> GetAllEmployees()
        {
            var users = await _userServices.GetEmployees();
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());
            return employees;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

            return model;
        }

        public async Task EditAllocation(LeaveAllocationEditVM leaveAllocationEditVM)
        {
            await _context.LeaveAllocations
                .Where(p => p.Id == leaveAllocationEditVM.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, leaveAllocationEditVM.Days));
        }

        private async Task<List<LeaveAllocation>> GetAllocationLeave(string? userId)
        {
            var currentDate = DateTime.Now;

            var leaveAllocations = await _context.LeaveAllocations
                .Include(a => a.LeaveType)
                .Include(p => p.Period)
                .Where(p => p.EmployeeId == userId && p.Period.EndDate.Year == currentDate.Year).ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
        {
            var period = await _periodsService.GetCurrentPeriod();
            var allocation = await _context.LeaveAllocations
                    .FirstAsync(q => q.LeaveTypeId == leaveTypeId
                    && q.EmployeeId == employeeId
                    && q.PeriodId == period.Id);
            return allocation;
        }

    }
}
