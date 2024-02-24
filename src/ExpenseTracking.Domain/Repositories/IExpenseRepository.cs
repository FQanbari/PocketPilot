using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Infrastructure.Repositories;

namespace ExpenseTracking.Domain.Repositories;

public interface IExpenseRepository : IGenericRepository<Expense>
{
    IEnumerable<Expense> GetByUser(int userId);
    IEnumerable<Expense> GetByCategoryAndDate(int userId, string category, DateTime startDate, DateTime endDate);
}

