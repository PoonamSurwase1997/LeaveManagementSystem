using LeaveManagementSystem.Application.Models.LeaveRequests;
using LeaveManagementSystem.Application.Service.LeaveRequests;
using LeaveManagementSystem.Application.Service.LeaveTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestsController(ILeaveTypeService _leaveTypeService, ILeaveRequestService _leaveRequestService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = await _leaveRequestService.GetEmployeeLeaveRequests();
        return View(model);
    }


    public async Task<IActionResult> Create(int? leaveTypeId)
    {
        var leaveType = await _leaveTypeService.GetAll();
        var leaveTypeList = new SelectList(leaveType, "Id", "Name", leaveTypeId);
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypes = leaveTypeList
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM leaveRequestCreateVM)
    {
        if (await _leaveRequestService.RequestDatesExceedAllocation(leaveRequestCreateVM))
        {
            ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
            ModelState.AddModelError(nameof(leaveRequestCreateVM.EndDate), "The number of days required is invalid");
        }

        if (ModelState.IsValid)
        {
            await _leaveRequestService.CreateLeaveRequest(leaveRequestCreateVM);
            RedirectToAction(nameof(Index));
        }

        var leaveType = await _leaveTypeService.GetAll();
        leaveRequestCreateVM.LeaveTypes = new SelectList(leaveType, "Id", "Name");

        return View(leaveRequestCreateVM);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
    {
        if (id == 0)
            return NotFound();

        await _leaveRequestService.CancelLeaveRequest(id);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> ListRequests()
    {
        var model = await _leaveRequestService.AdminGeteaveRequests();
        return View(model);
    }


    public async Task<IActionResult> Review(int id)
    {
        var model = await _leaveRequestService.GetLeaveRequestForReview(id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Review(int id, bool approved)
    {
        await _leaveRequestService.ReviewLeaveRequest(id, approved);
        return RedirectToAction(nameof(ListRequests));
    }
}
