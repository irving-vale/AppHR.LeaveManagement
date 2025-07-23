using HR.LeaveManagament.Persistence.DatabaseContext;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagament.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
    }


    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        return await _context.LeaveRequests
            .Include(lr => lr.LeaveType)
            .FirstOrDefaultAsync(lr => lr.Id == id);
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(lr => lr.LeaveType)
            .ToListAsync();
        return leaveRequests;
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
    {
        var leaveRequests =await _context.LeaveRequests
            .Include(lr => lr.LeaveType)
            .Where(lr => lr.RequestingEmployeeId == userId)
            .ToListAsync();
        return leaveRequests;
    }
}