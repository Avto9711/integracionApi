using integracion.api.Models.Generic;
using Microsoft.EntityFrameworkCore;

namespace integracion.api.Models.Context{

    public class IntegrationDbContext: DbContext{

            public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
            : base(options)
            {
                
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Employee>().HasQueryFilter(y=>!y.Deleted);
                modelBuilder.Entity<EntryType>().HasQueryFilter(y=>!y.Deleted);
                modelBuilder.Entity<DeductionType>().HasQueryFilter(y=>!y.Deleted);
                modelBuilder.Entity<GeneralLedger>().HasQueryFilter(y=>!y.Deleted);
                modelBuilder.Entity<RosterType>().HasQueryFilter(y=>!y.Deleted);
                modelBuilder.Entity<Transaction>().HasQueryFilter(y=>!y.Deleted);
                // foreach (var item in modelBuilder.Model.GetEntityTypes())
                // {
                // //     var type = item.GetType();  
                // // modelBuilder.Entity<typeof(type)>
                // //     .HasQueryFilter(post => EF.Property<bool>(post, "Deleted") == false);
                // }

            }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<EntryType> EntryTypes { get; set; }
            public DbSet<DeductionType> DeductionTypes { get; set; }
            public DbSet<GeneralLedger> GeneralLedgers { get; set; }
            public DbSet<RosterType> RosterTypes { get; set; }
            public DbSet<Transaction> Transactions { get; set; }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


          private void OnBeforeSaving()
            {
                foreach (var entry in ChangeTracker.Entries<BaseModel>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["Deleted"] = true;
                            break;
                    }
                }
            }

    }

}