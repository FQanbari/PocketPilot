using System.Linq;

namespace ExpenseTracking.UnitTests;

public class CreateExpenceHandlerTest
{
    [Fact]
    public void Should_Create_Expence()
    {
        var expence = new Expense
        {
            Name = "Pitza",
            Category = new CategoryExpense
            {
                Id = 1,
                Name = "Food"
            },
            Date = DateTime.Now,
            Amount = new Money(200_000M, "IRR"),
            Description = "from pose" ,
            BuyingType = BuyingType.Internet
        };
        var handler = new CreateExpenceHandler();


        handler.ExpenceService(expence);



    }

    [Fact]
    public void Should_Update_Expence()
    {
        var expence = new Expense
        {
            Id = 1,
            Name = "Pizza",
            Category = new CategoryExpense
            {
                Id = 1,
                Name = "Fastfood"
            },
            Date = DateTime.Now,
            Amount = new Money(160_000M, "IRR"),
            Description = "web site sanppfood",
            BuyingType = BuyingType.Internet
        };

        var handler = new UpdateExpenceHandler();

        handler.ExpenceService( expence );
    }

    [Fact]
    public void AddExpense_ShouldIncreaseExpenseListCount()
    {
        // Arrange
        ExpenseTracker expenseTracker = new ExpenseTracker();
        Expense expense = new Expense(50.00m, "Food", DateTime.Now, "Lunch");

        // Act
        expenseTracker.AddExpense(expense);

        // Assert
        Assert.Equal(1, expenseTracker.Expenses.Count);
    }

    [Fact]
    public void CategoryManagement_AddCategory_ShouldIncreaseCategoryCount()
    {
        // Arrange
        ExpenseTracker expenseTracker = new ExpenseTracker();

        // Act
        expenseTracker.AddCategory("Groceries");

        // Assert
        Assert.Equal(1, expenseTracker.Categories.Count);
    }

    [Fact]
    public void CategoryManagement_EditCategory_ShouldModifyCategoryName()
    {
        // Arrange
        ExpenseTracker expenseTracker = new ExpenseTracker();
        expenseTracker.AddCategory("Dining Out");

        // Act
        expenseTracker.EditCategory("Dining Out", "Restaurant Meals");

        // Assert
        Assert.True(expenseTracker.Categories.Any(x => x.Name == "Restaurant Meals"));
    }

    [Fact]
    public void CategoryManagement_DeleteCategory_ShouldDecreaseCategoryCount()
    {
        // Arrange
        ExpenseTracker expenseTracker = new ExpenseTracker();
        expenseTracker.AddCategory("Entertainment");

        // Act
        expenseTracker.DeleteCategory("Entertainment");

        // Assert
        Assert.Equal(0, expenseTracker.Categories.Count);
    }

    [Fact]
    public void ExpenseModification_EditExpense_ShouldModifyExpenseDetails()
    {
        // Arrange
        ExpenseTracker expenseTracker = new ExpenseTracker();
        Expense originalExpense = new Expense(30.00m, "Shopping", DateTime.Now, "Clothing");
        expenseTracker.AddExpense(originalExpense);

        // Act
        Expense modifiedExpense = new Expense(40.00m, "Shopping", DateTime.Now, "Shoes");
        expenseTracker.EditExpense(originalExpense, modifiedExpense);

        // Assert
        Assert.Equal(1, expenseTracker.Expenses.Count);
        Assert.Equal(40.00m, expenseTracker.Expenses.First().Amount.Value);
        Assert.Equal("Shoes", expenseTracker.Expenses.First().Category.Name);
    }

    [Fact]
    public void ExpenseModification_DeleteExpense_ShouldDecreaseExpenseListCount()
    {
        // Arrange
        ExpenseTracker expenseTracker = new ExpenseTracker();
        Expense expenseToDelete = new Expense(25.00m, "Utilities", DateTime.Now, "Electricity");
        expenseTracker.AddExpense(expenseToDelete);

        // Act
        expenseTracker.DeleteExpense(expenseToDelete);

        // Assert
        Assert.Equal(0, expenseTracker.Expenses.Count);
    }
}
