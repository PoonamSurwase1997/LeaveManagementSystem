namespace LeaveManagementSystem.Web.Service.Periods
{
    public interface IPeriodService
    {
        Task<Period> GetCurrentPeriod();
    }
}
