using ExpenseTracking.Domain.ValueObjects;

namespace ExpenseTracking.Domain.Entities;

public class Expense : BaseObject
{
    public Guid Id { get; private set; }
    public int UserId { get; private set; }
    public Money Amount { get; private set; }
    public string Category { get; private set; }
    public DateTime Date { get; private set; }
    public string Notes { get; private set; }
    public bool IsDeleted { get; private set; }

    public Expense() { } // Required for EF Core

    public Expense(Money amount, string category, DateTime date, string notes)
    {
        ArgumentNullException.ThrowIfNull(amount);

        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentNullException(nameof(category));
        }
        if (string.IsNullOrWhiteSpace(notes))
        {
            throw new ArgumentNullException(nameof(notes));
        }
        Id = Guid.NewGuid();
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        Category = category ?? throw new ArgumentNullException(nameof(category));
        Date = date;
        Notes = notes;
        IsDeleted = false;
    }

    public void CategorizeExpense(string newCategory)
    {
        if (string.IsNullOrWhiteSpace(newCategory))
        {
            throw new ArgumentNullException(nameof(newCategory));
        }
        Category = newCategory ?? throw new ArgumentNullException(nameof(newCategory));
    }

    public void ChangeAmount(decimal newAmount, string newCurrency)
    {
        Amount = new Money(newAmount, newCurrency);
    }
    public void DeleteExpense()
    {
        IsDeleted = true;
    }
}
