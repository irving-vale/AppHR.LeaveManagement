using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypesDetailsQuery(int Id): IRequest<LeaveTypeDetailsDto>
    {
        // Esta clase no tiene propiedades adicionales, ya que no se requieren parámetros para esta consulta
        // La respuesta será una lista de LeaveTypeDetailsDto, que representa los detalles de los tipos de licencia
        // Puede ser la clase normal o record, pero se recomienda usar record para consultas simples
    }

}
