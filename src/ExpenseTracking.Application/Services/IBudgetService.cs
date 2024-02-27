using ExpenseTracking.Application.DTO;
using ExpenseTracking.Domain.Entities;

namespace ExpenseTracking.Application.Services;

public interface IBudgetService
{
    Task<Budget> GetBudgetByCategoryAsync(int userId, string category);
    Task<bool> BudgetExistsAsync(int userId, string category);
    Task CreateBudgetAsync(BudgetDto budgetDto);
    Task UpdateBudgetAsync(BudgetDto budgetDto);
}