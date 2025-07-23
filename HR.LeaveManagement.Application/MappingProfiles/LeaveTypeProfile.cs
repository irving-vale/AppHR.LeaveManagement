using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile: Profile
    {
        public LeaveTypeProfile()
        {
            // Para Querys
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType,LeaveTypeDetailsDto>();

            // Para Commands
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
                
        }
    }
    
}
