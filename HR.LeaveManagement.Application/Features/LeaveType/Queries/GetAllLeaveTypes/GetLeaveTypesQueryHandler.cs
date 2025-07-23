using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    // clase de solicitud query que se define para obtener todos los tipos de licencia
    // implementa IRequestHandler de MediatR para definir el tipo de respuesta esperado usando el DTO LeaveTypeDto y el Query GetLeaveTypesQuery que usa Irequest<List<LeaveTypeDto>>
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {

        private readonly ILeaveTypeRepository _IleaveTypeRepository;
        private readonly IMapper _mapper;

        // Constructor que recibe el IMapper y el ILeaveTypeRepository para inyección de dependencias
        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository IleaveTypeRepositor)
        {
            this._mapper = mapper;
            this._IleaveTypeRepository = IleaveTypeRepositor;

        }

        // Implementación del método Handle que maneja la solicitud de obtener todos los tipos de licencia y devuelve una lista de DTOs
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _IleaveTypeRepository.GetAsync();

            // convert data objects to DTO objects
            var leaveTypeDtos = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list DTO objects
            return leaveTypeDtos; 
        }
    }
}
