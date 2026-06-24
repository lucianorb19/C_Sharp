using BarberShop.Application.UseCases.Billings.GetAll;
using BarberShop.Application.UseCases.Billings.GetById;
using BarberShop.Application.UseCases.Billings.Register;
using BarberShop.Communication.Requests;
using BarberShop.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BillingController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortBillingJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterBillingUseCase useCase,
        [FromBody] RequestBillingJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseBillingsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllBillings([FromServices] IGetAllBillingsUseCase useCase)
    {
        var response = await useCase.Execute();
        if (response.Billings.Count != 0) return Ok(response);
        return NoContent();

    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseBillingJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetBillingByIdUseCase useCase,
        [FromRoute] Guid id)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }





}
