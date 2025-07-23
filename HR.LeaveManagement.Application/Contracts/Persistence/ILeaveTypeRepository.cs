using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository: IGenericRepository<LeaveType>
{
    
    public Task<bool> IsLeaveTypeUnique(string name);
  
}
