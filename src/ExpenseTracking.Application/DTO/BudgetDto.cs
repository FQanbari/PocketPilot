namespace ExpenseTracking.Application.DTO;

public class BudgetDto
{
    public int UserId { get; set; }
    public string Category { get; set; }
    public decimal AllocatedAmount { get; set; }
    //public PaymentWay PaymentWay { get; set; }
}
//public enum PaymentWay
//{
//    Cash = 1, CrditCard = 2,
//}

//public class ExpenseDto
//{
//    public PaymentWay PaymentWay { get; set; }
//    public int CategoryId { get; set; }
//    public string CategoryTitle { get; set; }
//    public string Description { get; set; }
//    public string Currency { get; set; }

//}