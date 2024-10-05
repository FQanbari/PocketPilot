namespace ExpenseTracking.Domain.Entities;

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