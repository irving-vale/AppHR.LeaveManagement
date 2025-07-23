using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    internal class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {  

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        // Constructor that receives the IMapper and ILeaveTypeRepository for dependency injection
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            // Validate incoming data
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Leave type name cannot be empty.");
            }

            // convert to domain entity object

            var leaveTypeToCreate = _mapper.Map<Domain.Entities.LeaveType>(request);

            //add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);


            //return Id of created object
            return leaveTypeToCreate.Id;

        }
    }
}
