using ExpenseTracking.Application.Queries.Expense;
using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Repositories;
using MediatR;

namespace ExpenseTracking.Application.Queries.Budget;

public class CreateBudgetQuery : IRequest
{
    public Guid Id { get; set; }
    public int UserId { get;  set; }
    public string Category { get; set; }
    public decimal AllocatedAmount { get; set; }
    public DateTime ExpiryDate { get; set; }
}
internal class CreateBudgetQueryHandler : IRequestHandler<CreateBudgetQuery>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBudgetRepository _budgetRepository;

    public CreateBudgetQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
        _budgetRepository = unitOfWork.GetRepository<IBudgetRepository, Domain.Entities.Budget>();
    }
    public async Task Handle(CreateBudgetQuery request, CancellationToken cancellationToken)
    {
        ValidateInput(request);
        var budget = await _budgetRepository.GetBudgetByCategoryAsync(request.UserId, request.Category);

        if(budget != null)
        {
            budget.AllocatedAmount = request.AllocatedAmount;
            await _budgetRepository.Update(budget, cancellationToken);
        }
        else 
            await _budgetRepository.Create(new Domain.Entities.Budget { UserId = request.UserId, Category = request.Category, AllocatedAmount = request.AllocatedAmount, ExpiryDate = request.ExpiryDate}, cancellationToken);
        
        _unitOfWork.Commit();
    }

    private void ValidateInput(CreateBudgetQuery request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
    }
}
