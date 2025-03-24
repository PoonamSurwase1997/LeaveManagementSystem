
using AutoMapper;
using LeaveManagementSystem.Application.Service.Users;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Service.LeaveRequests
{
    public class LeaveRequestService(ApplicationDbContext _context, IMapper _mapper,
        IPeriodService _periodsService, IUserServices _userServices,
        ILeaveAllocationsService _leaveAllocationsService) : ILeaveRequestService
    {
        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Canceled;

            //var period = await _periodService.GetCurrentPeriod();

            //var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
            //var allocationToDeduct = await _context.LeaveAllocations.
            //    FirstAsync(a => a.LeaveTypeId == leaveRequest.LeaveTypeId && a.EmployeeId == leaveRequest.EmployeeId && a.PeriodId == period.Id);

            //allocationToDeduct.Days += numberOfDays;
            await UpdateAllocationDays(leaveRequest, false);
            await _context.SaveChangesAsync();
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            var user = await _userServices.GetLoggedUser();

            leaveRequest.EmployeeId = user.Id;
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;
            _context.Add(leaveRequest);

            //var period = await _periodService.GetCurrentPeriod();

            //var numberOfDays=model.EndDate.DayNumber-model.StartDate.DayNumber;
            //var allocationToDeduct = await _context.LeaveAllocations.
            //    FirstAsync(a => a.LeaveTypeId == model.LeaveTypeId && a.EmployeeId == user.Id && a.PeriodId == period.Id);

            //allocationToDeduct.Days -= numberOfDays;
            await UpdateAllocationDays(leaveRequest, true);
            await _context.SaveChangesAsync();

        }

        public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests()
        {
            var user = await _userServices.GetLoggedUser();

            var leaveRequest = await _context.LeaveRequests
                .Include(a => a.LeaveType).Where(a => a.EmployeeId == user.Id).ToListAsync();

            var model = leaveRequest.Select(l => new LeaveRequestReadOnlyVM
            {
                Id = l.Id,
                StartDate = l.StartDate,
                EndDate = l.EndDate,
                LeaveType = l.LeaveType.Name,
                LeaveRequestStatusEnum = (LeaveRequestStatusEnum)l.LeaveRequestStatusId,
                NumberOfDays = l.EndDate.DayNumber - l.StartDate.DayNumber,
            }).ToList();

            return model;
        }


        public async Task<EmployeeLeaveRequestListVM> AdminGeteaveRequests()
        {
            var leaveRequests = await _context.LeaveRequests.Include(a => a.LeaveType).ToListAsync();

            var approvedLeaveRequests = leaveRequests.Count(a => a.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Approved);
            var pendingLeaveRequests = leaveRequests.Count(a => a.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Pending);
            var declinedLeaveRequests = leaveRequests.Count(a => a.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Declined);
            var canceledLeaveRequests = leaveRequests.Count(a => a.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Canceled);

            var leaveRequestsModel = leaveRequests.Select(p => new LeaveRequestReadOnlyVM
            {
                Id = p.Id,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                NumberOfDays = p.EndDate.DayNumber - p.StartDate.DayNumber,
                LeaveType = p.LeaveType.Name,
                LeaveRequestStatusEnum = (LeaveRequestStatusEnum)p.LeaveRequestStatusId,
            }).ToList();


            var model = new EmployeeLeaveRequestListVM
            {
                ApprovedRequests = approvedLeaveRequests,
                PendingRequests = pendingLeaveRequests,
                RejectedRequests = declinedLeaveRequests,
                TotalRequests = leaveRequests.Count,
                LeaveRequests = leaveRequestsModel,
            };

            return model;
        }

        public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
        {
            var user = await _userServices.GetLoggedUser();

            var period = await _periodsService.GetCurrentPeriod();

            var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;

            var allocationToDeduct = await _context.LeaveAllocations.
                            FirstAsync(a => a.LeaveTypeId == model.LeaveTypeId && a.EmployeeId == user.Id && a.PeriodId == period.Id);

            return allocationToDeduct.Days > numberOfDays;
        }

        public Task<LeaveRequestListVM> GetAllLeaveRequests()
        {
            throw new NotImplementedException();
        }


        public async Task ReviewLeaveRequest(int leaveRequestId, bool approved)
        {
            var user = await _userServices.GetLoggedUser();
            var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
            leaveRequest.LeaveRequestStatusId = approved ? (int)LeaveRequestStatusEnum.Approved : (int)LeaveRequestStatusEnum.Declined;

            leaveRequest.ReviewerId = user.Id.ToString();
            if (!approved)
            {
                //var period = await _periodService.GetCurrentPeriod();

                //var allocation = await _context.LeaveAllocations.FirstAsync(a => a.LeaveTypeId == leaveRequest.LeaveTypeId && a.EmployeeId == leaveRequest.EmployeeId && a.PeriodId == period.Id);
                //var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
                //allocation.Days += numberOfDays;
                await UpdateAllocationDays(leaveRequest, false);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ReviewLeaveRequesVM> GetLeaveRequestForReview(int id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(a => a.LeaveType)
                .FirstAsync(a => a.Id == id);

            var user = await _userServices.GetUserById(leaveRequest.EmployeeId);

            var model = new ReviewLeaveRequesVM
            {
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                Id = leaveRequest.Id,
                NumberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber,
                LeaveRequestStatusEnum = (LeaveRequestStatusEnum)leaveRequest.LeaveRequestStatusId,
                LeaveType = leaveRequest.LeaveType.Name,
                Employee = new EmployeeListVM
                {
                    Id = leaveRequest.EmployeeId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                }
            };
            return model;
        }


        private async Task UpdateAllocationDays(LeaveRequest leaveRequest, bool deductDays)
        {
            var allocation = await _leaveAllocationsService.GetCurrentAllocation(leaveRequest.LeaveTypeId, leaveRequest.EmployeeId);

            var numberOfDays = CalculateDays(leaveRequest.StartDate, leaveRequest.EndDate);

            if (deductDays)
            {
                allocation.Days -= numberOfDays;
            }
            else
            {
                allocation.Days += numberOfDays;
            }
            _context.Entry(allocation).State = EntityState.Modified;
        }

        private int CalculateDays(DateOnly start, DateOnly end)
        {
            return end.DayNumber - start.DayNumber;
        }


    }
}
