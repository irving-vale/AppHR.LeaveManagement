using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    internal class GetLeaveTypesDetailQueryHandler : IRequestHandler<GetLeaveTypesDetailsQuery,LeaveTypeDetailsDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        // Constructor that receives the IMapper and ILeaveTypeRepository for dependency injection
        public GetLeaveTypesDetailQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }


        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
        {

            // Query the database for the specific leave type by Id
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Convert data object to DTO object
            var leaveTypeDto = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);

            return leaveTypeDto;



        }
    }
}
