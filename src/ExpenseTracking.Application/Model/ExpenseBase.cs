namespace ExpenseTracking.Application.Model;

public abstract class ExpenseBase
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
}