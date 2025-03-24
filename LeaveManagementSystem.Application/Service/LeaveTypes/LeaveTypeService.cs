using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Service.LeaveTypes;

public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
{
    public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
    {
        var data = await _context.LeaveTypes.ToListAsync();
        var viewdata = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewdata;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(p => p.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(p => p.Id == id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }


    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name, int id)
    {
        return await _context.LeaveTypes.AnyAsync(p => p.Name.ToLower().Equals(name.ToLower()) && (id != p.Id || p.Id == 0));
    }

    public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);
        return leaveType.NumberOfDays < days;
    }
}
