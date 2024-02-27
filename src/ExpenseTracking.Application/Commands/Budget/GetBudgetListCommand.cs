using ExpenseTracking.Application.DTO;
using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Application.Commands.Budget;

public class GetBudgetListCommand : IRequest<List<BudgetDto>>
{
    public int UserId { get; set; }
}
public class GetBudgetListCommandHandler : IRequestHandler<GetBudgetListCommand, List<BudgetDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBudgetRepository _budgetRepository;

    public GetBudgetListCommandHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
        _budgetRepository = unitOfWork.GetRepository<IBudgetRepository, Domain.Entities.Budget>();
    }
    public async Task<List<BudgetDto>> Handle(GetBudgetListCommand request, CancellationToken cancellationToken)
    {
        var budgets = await _budgetRepository.GetList(x => x.UserId == request.UserId, cancellationToken);

        return budgets.Select(x => new BudgetDto { UserId = x.UserId, Category = x.Category, AllocatedAmount = x.AllocatedAmount });
    }
}