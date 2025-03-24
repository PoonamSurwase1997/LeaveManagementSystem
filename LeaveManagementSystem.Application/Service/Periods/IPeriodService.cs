namespace LeaveManagementSystem.Application.Service.Periods
{
    public interface IPeriodService
    {
        Task<Period> GetCurrentPeriod();
    }
}
