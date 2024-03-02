using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Infrastructure.Utilites;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Infrastructure.Context;

public class AppDbContext : DbContext
{
    

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entitiesAssembly = typeof(IEntity).Assembly;

        modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
        modelBuilder.AddRestrictDeleteBehaviorConvention();
        modelBuilder.AddPluralizingTableNameConvention();

    }
}
