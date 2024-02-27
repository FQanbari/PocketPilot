using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        => result is null ? NotFound() : Ok(result);
}
