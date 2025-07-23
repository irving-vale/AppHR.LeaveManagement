using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetails(int leaveTypeId);
    Task<bool> AllocationExists(int leaveTypeId, string userId, int period);
    Task AddAllocations(IEnumerable<LeaveAllocation> allocations);
    Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);

}
