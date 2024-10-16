﻿using ExpenseTracking.Domain.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracking.Domain.Entities;

public class Budget : BaseEntity<Guid>
{
    public int UserId { get; set; }
    public string Category { get; set; }
    public string Amount { get; set; }
    //public decimal AllocatedAmount { get; set; }
    //public decimal RemainingAmount => AllocatedAmount - TotalSpentAmount;
    //public decimal TotalSpentAmount { get; private set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


    //public void RecordExpense(decimal expenseAmount)
    //{
    //    if (RemainingAmount <= 0) throw new BudgetNotEnoughException(RemainingAmount);
    //    TotalSpentAmount += expenseAmount;
    //}
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}
