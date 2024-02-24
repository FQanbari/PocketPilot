
namespace ExpenseTracking;

internal class CreateExpenseHandler
{
    private ExpenseTracker expenseTracker;

    public CreateExpenseHandler(ExpenseTracker expenseTracker)
    {
        this.expenseTracker = expenseTracker;
    }

    internal void HandleCreateExpense(Expense expense)
    {
        expenseTracker.AddExpense(expense);
    }
}