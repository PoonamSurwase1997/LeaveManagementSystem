using Microsoft.AspNetCore.Http;

namespace LeaveManagementSystem.Application.Service.Users
{
    public class UserServices(UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserServices
    {
        public async Task<ApplicationUser> GetLoggedUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            return user;
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<List<ApplicationUser>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            return employees.ToList();
        }
    }
}
