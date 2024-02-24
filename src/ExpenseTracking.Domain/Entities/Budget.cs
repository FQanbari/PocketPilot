using ExpenseTracking.Domain.Exceptions;

namespace ExpenseTracking.Domain.Entities;

public class Budget : BaseObject
{
    public int UserId { get; set; }
    public string Category { get; set; }
    public decimal AllocatedAmount { get; set; }
    public decimal RemainingAmount => AllocatedAmount - TotalSpentAmount;
    public decimal TotalSpentAmount { get; private set; }


    public void RecordExpense(decimal expenseAmount)
    {
        if (RemainingAmount <= 0) throw new BudgetNotEnoughException(RemainingAmount);
        TotalSpentAmount += expenseAmount;
    }
}
