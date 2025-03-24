namespace LeaveManagementSystem.Application.Service.LeaveTypes
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name, int id);
        Task Create(LeaveTypeCreateVM model);
        Task<bool> DaysExceedMaximum(int id, int days);
        Task Edit(LeaveTypeEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAll();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}