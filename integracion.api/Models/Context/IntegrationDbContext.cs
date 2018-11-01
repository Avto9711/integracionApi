using Microsoft.EntityFrameworkCore;

namespace integracion.api.Models.Context{

    public class IntegrationDbContext: DbContext{

            public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
            : base(options)
            {
                
            }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<EntryType> EntryTypes { get; set; }
            
    }

}