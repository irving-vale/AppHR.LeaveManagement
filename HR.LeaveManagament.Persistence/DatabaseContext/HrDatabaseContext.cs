using HR.LeaveManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagament.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
    // Define DbSet properties for your entities here
    // Example: public DbSet<LeaveType> LeaveTypes { get; set; }
    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
    {

    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now; // Set the DateModified property to the current time
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now; // Set the DateCreated property to the current time for new entities
            }

        }
        // You can add custom logic here before saving changes, such as auditing or validation
        return base.SaveChangesAsync(cancellationToken);
    }

   

}

