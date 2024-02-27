using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ExpenseTracking.Infrastructure.Repositories;

public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{
    private readonly DbSet<Expense> _dbSet;

    public ExpenseRepository(DbSet<Expense> dbSet)    
        :base(dbSet)
    {
        _dbSet = dbSet;
    }

    public IEnumerable<Expense> GetByUser(int userId)
    {
        return _dbSet.Where(e => e.UserId == userId).ToList();
    }

    public IEnumerable<Expense> GetByCategoryAndDate(int userId, string category, DateTime startDate, DateTime endDate)
    {
        return _dbSet
            .Where(e => e.UserId == userId && e.Category == category && e.Date >= startDate && e.Date <= endDate)
            .ToList();
    }
}
