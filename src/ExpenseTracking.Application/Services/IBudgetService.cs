using ExpenseTracking.Application.DTO;
using ExpenseTracking.Domain.Entities;

namespace ExpenseTracking.Application.Services;

public interface IBudgetService
{
    // Retrieve the budget for a specific user and category
    Task<Budget> GetBudgetByCategoryAsync(int userId, string category);

    // Check if a budget exists for a specific user and category
    Task<bool> BudgetExistsAsync(int userId, string category);

    // Create a new budget for a user
    Task CreateBudgetAsync(BudgetDto budgetDto);

    // Update an existing budget
    Task UpdateBudgetAsync(BudgetDto budgetDto);
}