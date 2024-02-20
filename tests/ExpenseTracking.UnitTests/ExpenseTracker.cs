
namespace ExpenseTracking.UnitTests
{
    internal class ExpenseTracker
    {
        public ExpenseTracker()
        {
        }

        public ICollection<Expense> Expenses { get; internal set; }
        public ICollection<CategoryExpense> Categories { get; internal set; }

        internal void AddCategory(string v)
        {
            throw new NotImplementedException();
        }

        internal void AddExpense(Expense expense)
        {
            throw new NotImplementedException();
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
}