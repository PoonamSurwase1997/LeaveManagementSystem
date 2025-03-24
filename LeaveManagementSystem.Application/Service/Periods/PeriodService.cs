using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Service.Periods
{
    public class PeriodService(ApplicationDbContext _context) : IPeriodService
    {
        public async Task<Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(a => a.EndDate.Year == currentDate.Year);
            return period;
        }
    }
}
