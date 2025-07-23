using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagament.Persistence.DatabaseContext;
using HR.LeaveManagament.Persistence.Repositories;
using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HR.LeaveManagament.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
            });
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
