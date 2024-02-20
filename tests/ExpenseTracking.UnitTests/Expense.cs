
namespace ExpenseTracking.UnitTests;

public class Expense
{
    public Expense(decimal amount, string category, DateTime date, string description)
    {
        Amount = new Money(amount, "IRR");
        Category = new CategoryExpense(category);
        Date = date;
        Description = description;
    }
    public string Name { get; set; }
    public CategoryExpense Category { get; set; }
    public DateTime Date { get; set; }
    public Money Amount { get; set; }
    public string Description { get; set; }
    public BuyingType BuyingType { get; set; }
    public int Id { get; internal set; }
}

public enum BuyingType
{
    Internet,
    Cash,
    Card,
}
public record Money
{
    public decimal Value { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Value cannot be negative");
        }

        // You might want to add currency validation logic here

        Value = amount;
        Currency = currency;
    }

    public Money Add(Money other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        if (Currency != other.Currency)
        {
            throw new InvalidOperationException("Currencies must match for addition");
        }

        return new Money(Value + other.Value, Currency);
    }

    public Money Subtract(Money other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        if (Currency != other.Currency)
        {
            throw new InvalidOperationException("Currencies must match for subtraction");
        }

        if (Value < other.Value)
        {
            throw new InvalidOperationException("Subtraction would result in a negative amount");
        }

        return new Money(Value - other.Value, Currency);
    }

    // Additional methods for multiplication, division, comparisons, etc., can be added as needed

    public override string ToString()
    {
        return $"{Value} {Currency}";
    }
}
