using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Application.Queries.Budget;

public class RemoveBudgetQuery : IRequest
{
    public Guid Id { get; set; }
}

internal class RemoveBudgetQueryHandler : IRequestHandler<RemoveBudgetQuery>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBudgetRepository _budgetRepository;

    public RemoveBudgetQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
        _budgetRepository = unitOfWork.GetRepository<IBudgetRepository, Domain.Entities.Budget>();
    }
    public async Task Handle(RemoveBudgetQuery request, CancellationToken cancellationToken)
    {
        ValidateInput(request);
        var budget = await _budgetRepository.Find(x => x.Id == request.Id, cancellationToken);

        if (budget != null)
        {
            await _budgetRepository.Delete(budget, cancellationToken);
        }
       
        await _unitOfWork.SaveChanges();
    }

    private void ValidateInput(RemoveBudgetQuery request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
    }
}
