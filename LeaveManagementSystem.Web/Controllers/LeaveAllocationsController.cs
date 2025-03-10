using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Service.LeaveAllocations;
using LeaveManagementSystem.Web.Service.LeaveTypes;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationsController(ILeaveAllocationsService _leaveAllocationsService,ILeaveTypeService _leaveTypeService) : Controller
    {
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var employees = await _leaveAllocationsService.GetAllEmployees();
            return View(employees);
        }

        [Authorize(Roles =Roles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? id)
        {
            await _leaveAllocationsService.AllocateLeave(id);
            return RedirectToAction(nameof(Details), new { userId = id });
        }

        public async Task<IActionResult> Details(string? userId)
        {
            var employeeAllocationVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);
            return View(employeeAllocationVM);
        }

        [Authorize(Roles =Roles.Administrator)]
        public async Task<IActionResult> EditAllocation(int? id)
        {
            if(id == null)
                return NotFound();

            var allocation = await _leaveAllocationsService.GetEmployeeAllocation(id.Value);
            if(allocation == null)
                return  NotFound();

            return View(allocation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocation)
        {
            if (await _leaveTypeService.DaysExceedMaximum(allocation.LeaveType.Id, allocation.Days))
            {
                ModelState.AddModelError("Days", "The allocation exceeds the maximum leave type value");
            }

            if (ModelState.IsValid)
            {
                await _leaveAllocationsService.EditAllocation(allocation);
                return RedirectToAction(nameof(Details), new { userId = allocation?.Employee?.Id });
            }
            return View(allocation);
        }
    }
}
