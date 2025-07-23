using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain.Entities;

public class LeaveAllocation : BaseEntity
{
    public string EmployeeId { get; set; } = string.Empty;
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int Period { get; set; }
}

