using ExpenseTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
