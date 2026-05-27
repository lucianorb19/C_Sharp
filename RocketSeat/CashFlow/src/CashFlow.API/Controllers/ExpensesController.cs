using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    //[ProducesResponseType()]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        var response = new RegisterExpenseUseCase().Execute(request);
        return Created(string.Empty, response);
    }
}
