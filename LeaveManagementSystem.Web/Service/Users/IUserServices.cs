namespace LeaveManagementSystem.Web.Service.Users
{
    public interface IUserServices
    {
        Task<ApplicationUser> GetLoggedUser();
        Task<ApplicationUser> GetUserById(string userId);
        Task<List<ApplicationUser>> GetEmployees();
    }
}
