//namespace ExpenseTracking.UnitTests;

//public class ExpenseTrackerTests
//{
//    [Fact]
//    public void AddExpense_ShouldIncreaseExpenseListCount()
//    {
//        // Arrange
//        ExpenseTracker _expenseTracker = new ExpenseTracker();
//        Expense expense = new Expense(50.00m, "Food", DateTime.Now, "Lunch");

//        // Act
//        _expenseTracker.AddExpense(expense);

//        // Assert
//        Assert.Equal(1, _expenseTracker.Expenses.Count);
//    }

//    [Fact]
//    public void CategoryManagement_AddCategory_ShouldIncreaseCategoryCount()
//    {
//        // Arrange
//        ExpenseTracker _expenseTracker = new ExpenseTracker();

//        // Act
//        _expenseTracker.AddCategory("Groceries");

//        // Assert
//        Assert.Equal(1, _expenseTracker.Categories.Count);
//    }

//    [Fact]
//    public void CategoryManagement_EditCategory_ShouldModifyCategoryName()
//    {
//        // Arrange
//        ExpenseTracker _expenseTracker = new ExpenseTracker();
//        _expenseTracker.AddCategory("Dining Out");

//        // Act
//        _expenseTracker.EditCategory("Dining Out", "Restaurant Meals");

//        // Assert
//        Assert.True(_expenseTracker.Categories.Contains("Restaurant Meals"));
//    }

//    [Fact]
//    public void CategoryManagement_DeleteCategory_ShouldDecreaseCategoryCount()
//    {
//        // Arrange
//        ExpenseTracker _expenseTracker = new ExpenseTracker();
//        _expenseTracker.AddCategory("Entertainment");

//        // Act
//        _expenseTracker.DeleteCategory("Entertainment");

//        // Assert
//        Assert.Equal(0, _expenseTracker.Categories.Count);
//    }

//    [Fact]
//    public void ExpenseModification_EditExpense_ShouldModifyExpenseDetails()
//    {
//        // Arrange
//        ExpenseTracker _expenseTracker = new ExpenseTracker();
//        Expense originalExpense = new Expense(30.00m, "Shopping", DateTime.Now, "Clothing");
//        _expenseTracker.AddExpense(originalExpense);

//        // Act
//        Expense modifiedExpense = new Expense(40.00m, "Shopping", DateTime.Now, "Shoes");
//        _expenseTracker.EditExpense(originalExpense, modifiedExpense);

//        // Assert
//        Assert.Equal(1, _expenseTracker.Expenses.Count);
//        Assert.Equal(40.00m, _expenseTracker.Expenses[0].Amount);
//        Assert.Equal("Shoes", _expenseTracker.Expenses[0].Category);
//    }

//    [Fact]
//    public void ExpenseModification_DeleteExpense_ShouldDecreaseExpenseListCount()
//    {
//        // Arrange
//        ExpenseTracker _expenseTracker = new ExpenseTracker();
//        Expense expenseToDelete = new Expense(25.00m, "Utilities", DateTime.Now, "Electricity");
//        _expenseTracker.AddExpense(expenseToDelete);

//        // Act
//        _expenseTracker.DeleteExpense(expenseToDelete);

//        // Assert
//        Assert.Equal(0, _expenseTracker.Expenses.Count);
//    }
//}