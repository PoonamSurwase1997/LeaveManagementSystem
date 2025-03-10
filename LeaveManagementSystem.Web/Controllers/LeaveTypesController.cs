using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using AutoMapper;
using System.Runtime.Intrinsics.Arm;
using LeaveManagementSystem.Web.Service.LeaveTypes;
using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController(ILeaveTypeService leaveTypeService) : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService = leaveTypeService;
        private const string NameExistsValidationMessage = "Leave type Name Already exists";


        public async Task<IActionResult> Index()
        {
            var viewdata = await _leaveTypeService.GetAll();
            return View(viewdata);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
                return NotFound();

            return View(leaveType);
        }


        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            if(await _leaveTypeService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name, 0))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                await _leaveTypeService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var leaveType = await _leaveTypeService.Get<LeaveTypeEditVM>(id.Value);

            if (leaveType == null)
                return NotFound();

            return View(leaveType);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEditVM)
        {
            if (id != leaveTypeEditVM.Id)
            {
                return NotFound();
            }

            if (await _leaveTypeService.CheckIfLeaveTypeNameExists(leaveTypeEditVM.Name, leaveTypeEditVM.Id))
            {
                ModelState.AddModelError(nameof(leaveTypeEditVM.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypeService.Edit(leaveTypeEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypeService.LeaveTypeExists(leaveTypeEditVM.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEditVM);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
                return NotFound();

            return View(leaveType);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeService.Remove(id);            
            return RedirectToAction(nameof(Index));
        }

    }
}
