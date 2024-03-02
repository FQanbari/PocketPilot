namespace ExpenseTracking.Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    public Money()
    {
        
    }
    public Money(decimal amount, string currency)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative.");
        }
        Amount = amount;
        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
    }

    public override string ToString()
        => $"{Amount} {Currency}";
}