namespace ExpenseTracking.Application.DTO;

public class BudgetDto
{
    public string UserId { get; set; }
    public string Category { get; set; }
    public decimal AllocatedAmount { get; set; }
}
