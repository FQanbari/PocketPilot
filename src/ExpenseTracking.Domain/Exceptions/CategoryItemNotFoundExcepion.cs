namespace ExpenseTracking.Domain.Exceptions;

public class ExpenceTrackingExpecption : Exception 
{
    public ExpenceTrackingExpecption(string message)
        :base(message)
    {
        
    }
}
internal class CategoryItemNotFoundExcepion : ExpenceTrackingExpecption
{
    public string Name { get; }
    public CategoryItemNotFoundExcepion(string name) : base($"This category name '{name}' does not exist.")
    {
        Name = name;
    }
}

public class BudgetNotEnoughException : ExpenceTrackingExpecption
{
    public decimal RemainingAmount { get; }
    public BudgetNotEnoughException(decimal remainingAmount) : base($"your buget (${remainingAmount}) not enough!!")
    {
        RemainingAmount = remainingAmount;
    }
}