using ExpenseTracking.Application.Model;
using ExpenseTracking.Application.Queries.Budget;
using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Repositories;
using MediatR;
using System.Reflection.Metadata;

namespace ExpenseTracking.Application.Queries.Expense;

public class CreateExpenseQuery : ExpenseBase, IRequest
{
    public Guid? Id { get; set; }
    public int UserId { get; internal set; }
}
public class CreateExpenseQueryHandler : IRequestHandler<CreateExpenseQuery>
{
    private ExpenseTracker _expenseTracker;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Domain.Entities.Expense> _expenceRepository;
    private readonly IBudgetRepository _budgetRepository;
    //private readonly IBudgetService _budgetService;

    public CreateExpenseQueryHandler(ExpenseTracker expenseTracker, IUnitOfWork unitOfWork, IBudgetService budgetService)
    {
        _expenseTracker = expenseTracker;
        _expenceRepository = unitOfWork.GetRepository<Domain.Entities.Expense>(); 
        _budgetRepository = unitOfWork.GetRepository<IBudgetRepository, Domain.Entities.Budget>(); 
        _unitOfWork = unitOfWork;
        //_budgetService = budgetService;
    }
    public async Task Handle(CreateExpenseQuery request, CancellationToken cancellationToken)
    {
        ValidateInput(request);
        var budget = await _budgetRepository.GetBudgetByCategoryAsync(request.UserId, request.Category);

        if (budget != null)
        {
            if (request.Amount > budget.AllocatedAmount)
            {
                // Trigger a notification if the expense exceeds the budget limit
                NotifyBudgetExceeded(request.UserId, budget);
            }
            await _expenceRepository.Create(ToExpense<Domain.Entities.Expense>(request), cancellationToken);
            _expenseTracker.AddExpense(request.Amount, "IIR", request.Category, request.Date, request.Notes);

            await _unitOfWork.SaveChanges();
        }
    }

    private void ValidateInput(CreateExpenseQuery expenseDto)
    {
        if (expenseDto == null)
        {
            throw new ArgumentNullException(nameof(expenseDto));
        }
    }
    private static Domain.Entities.Expense ToExpense<TResult>(CreateExpenseQuery dto)
        => new Domain.Entities.Expense(new Domain.ValueObjects.Money(dto.Amount, "IRR"), dto.Category, dto.Date, dto.Notes);

    private void NotifyBudgetExceeded(int userId, Domain.Entities.Budget budget)
    {
        var notificationContent = $"Expense exceeded budget limit for category {budget.Category}.";
        //_notificationService.SendNotification(userId, notificationContent);
    }
}