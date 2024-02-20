namespace ExpenseTracking.UnitTests;

public class CategoryExpense
{
    public CategoryExpense(string name)
    {
        Name = name;   
    }
    public int Id { get; set; }
    public string Name { get; set; }
}