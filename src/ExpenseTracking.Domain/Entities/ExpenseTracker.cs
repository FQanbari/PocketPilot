

using ExpenseTracking.Domain.Exceptions;
using ExpenseTracking.Domain.ValueObjects;

namespace ExpenseTracking.Domain.Entities;

public class ExpenseTracker : BaseObject
{
    private readonly List<Expense> _expenses = new List<Expense>();
    private readonly List<Category> _categories = new List<Category>();

    public IReadOnlyList<Expense> Expenses => _expenses.AsReadOnly();
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();

    public void AddExpense(decimal amount, string currency, string category, DateTime date, string notes)
    {
        var money = new Money(amount, currency);
        var expense = new Expense(money, category, date, notes);
        _expenses.Add(expense);
    }
    public void EditCategory(string categoryName, string newCategoryName)
    {
        var category = GetCategoryItem(categoryName);
        category.ChangeName(newCategoryName);
    }
    public void DeleteExpense(Expense expenseToDelete)
    {
        if (expenseToDelete == null)
        {
            throw new ArgumentNullException(nameof(expenseToDelete));
        }

        if (_expenses.Contains(expenseToDelete) && !expenseToDelete.IsDeleted)
        {
            expenseToDelete.DeleteExpense();
        }
    }

    public void AddCategory(string categoryName)
    {
        var category = new Category(categoryName);
        _categories.Add(category);
    }    
    public void DeleteCategory(string v)
    {
        throw new NotImplementedException();
    }
    private  Category GetCategoryItem(string categoryName)
    {
        var item = _categories.SingleOrDefault(i => i.Name == categoryName);

        if (item is null) throw new CategoryItemNotFoundExcepion(categoryName);

        return item;
    }
}
public class Category
{
    public string Name { get; private set; }

    private Category() { } // Required for EF Core

    public Category(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void ChangeName(string newName)
    {
        Name = newName ?? throw new ArgumentNullException(nameof(newName));
    }
}