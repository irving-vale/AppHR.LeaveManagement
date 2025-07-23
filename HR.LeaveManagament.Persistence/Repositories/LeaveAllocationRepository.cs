using HR.LeaveManagament.Persistence.DatabaseContext;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagament.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }


    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .FirstOrDefaultAsync(la => la.Id == id);
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        return await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .Where(la => la.EmployeeId == userId)
            .ToListAsync();
        
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails(int leaveTypeId)
    {
        return await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .Where(la => la.LeaveTypeId == leaveTypeId)
            .ToListAsync();
    }

    public async Task<bool> AllocationExists(int leaveTypeId, string userId, int period)
    {
       return await  _context.LeaveAllocations.AnyAsync(q => 
            q.EmployeeId == userId && 
            q.LeaveTypeId == leaveTypeId && 
            q.Period == period);
    }

    public async Task AddAllocations(IEnumerable<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _context.LeaveAllocations
            .Include(la => la.LeaveType)
            .FirstOrDefaultAsync(la => la.EmployeeId == userId && la.LeaveTypeId == leaveTypeId);
    }
}