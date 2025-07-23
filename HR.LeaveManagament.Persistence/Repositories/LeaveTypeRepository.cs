using HR.LeaveManagament.Persistence.DatabaseContext;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagament.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(x => x.Name == name);
    }
}