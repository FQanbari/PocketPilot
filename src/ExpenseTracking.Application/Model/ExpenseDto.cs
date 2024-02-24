namespace ExpenseTracking.Application.Model;

public class ExpenseDto : ExpenseBase
{
    public int? Id { get; set; }
    public int UserId { get; internal set; }
}
