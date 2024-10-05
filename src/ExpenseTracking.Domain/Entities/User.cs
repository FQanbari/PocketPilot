using System.Collections.ObjectModel;

namespace ExpenseTracking.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string  UserName { get; set; }
    public string  Password { get; set; }
    public string  Email { get; set; }
    public string  ProfileAddress { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginDate { get; set; }

    public ICollection<Budget> Budgets { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<SavingGoal> SavingGoals { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Bill> Bills { get; set; }

}