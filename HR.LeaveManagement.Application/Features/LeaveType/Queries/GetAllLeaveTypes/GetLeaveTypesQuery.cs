using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    // clase de solicitud query que se define para obtener todos los tipos de licencia
    // implementa IRequest de MediatR para definir el tipo de respuesta esperado
    // no van los metodos de consulta aquí, solo la definición de la clase

    // public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    // {
    //}

    // Esta clase no tiene propiedades adicionales, ya que no se requieren parámetros para esta consulta
    // La respuesta será una lista de LeaveTypeDto, que representa los tipos de licencia
    // puede ser la clase normal o record, pero se recomienda usar record para consultas simples
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;

    

}