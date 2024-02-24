
namespace ExpenseTracking;

internal class ExpenseTracker
{
    public List<Expense> Expenses = new();
    public IList<string> Categories { get; internal set; }

    internal void AddCategory(string v)
    {
        throw new NotImplementedException();
    }

    internal void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
    }

    internal void DeleteCategory(string v)
    {
        throw new NotImplementedException();
    }

    internal void DeleteExpense(Expense expenseToDelete)
    {
        throw new NotImplementedException();
    }

    internal void EditCategory(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    internal void EditExpense(Expense originalExpense, Expense modifiedExpense)
    {
        throw new NotImplementedException();
    }
}