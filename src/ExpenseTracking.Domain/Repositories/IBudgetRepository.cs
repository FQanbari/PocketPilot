using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Infrastructure.Repositories;

namespace ExpenseTracking.Domain.Repositories;

public interface IBudgetRepository : IGenericRepository<Budget>
{
    Task<Budget> GetBudgetByCategoryAsync(int userId, string category);
}

