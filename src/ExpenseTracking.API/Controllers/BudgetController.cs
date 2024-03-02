using ExpenseTracking.Application.Commands.Budget;
using ExpenseTracking.Application.DTO;
using ExpenseTracking.Application.Queries.Budget;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.API.Controllers;

public class BudgetController(IMediator mediator) : BaseController(mediator)
{

    [HttpGet("{userId:int}")]
    public async Task<ActionResult<List<BudgetDto>>> Get([FromRoute] GetBudgetListCommand query)
    {
        var result = await mediator.Send(query);
        return OkOrNotFound(result);
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBudgetQuery command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] RemoveBudgetQuery command)
    {
        await mediator.Send(command);
        return Ok();
    }
}