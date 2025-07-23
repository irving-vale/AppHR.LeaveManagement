using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain.Entities;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    internal class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        // Constructor that receives the IMapper and ILeaveTypeRepository for dependency injection
        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            // find the entity object by id 
           Domain.Entities.LeaveType leavetypeToUpdateFindById = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leavetypeToUpdateFindById == null)
            {
                throw new KeyNotFoundException($"LeaveTypeWhit ID {request.Id} was not found.");
            }


          
            // Update in database
           await _leaveTypeRepository.UpdateAsync(leavetypeToUpdateFindById);

            // Return Unit to indicate completion
            return Unit.Value;
        }
        }
    }
