namespace ExpenseTracking.Application.DTO;

public class BudgetDto
{
    public int UserId { get; set; }
    public string Category { get; set; }
    public decimal AllocatedAmount { get; set; }
}
