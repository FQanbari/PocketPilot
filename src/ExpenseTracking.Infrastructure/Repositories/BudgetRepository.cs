using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Infrastructure.Repositories;

public class BudgetRepository : GenericRepository<Budget>, IBudgetRepository
{
    private readonly DbSet<Budget> _dbSet;
    public BudgetRepository(DbSet<Budget> dbSet) : base(dbSet)
    {
        _dbSet = dbSet;
    }

    public async Task<Budget> GetBudgetByCategoryAsync(int userId, string category)
    {
        return _dbSet.Where(x => x.UserId == userId &&  x.Category == category).FirstOrDefault();
    }
}