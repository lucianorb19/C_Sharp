using BarberShop.Application.UseCases.Billings.Reports.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BarberShop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel/month")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateMonthBillingsReportExcelUseCase useCase,
        [FromHeader] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);
        if (file.Length > 0) return File(file, MediaTypeNames.Application.Octet, "reportMonth.xlsx");
        return NoContent();
    }


    [HttpGet("excel/week")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateWeekBillingsReportExcelUseCase useCase)
    {
        byte[] file = await useCase.Execute();
        if (file.Length > 0) return File(file, MediaTypeNames.Application.Octet, "reportWeek.xlsx");
        return NoContent();
    }


    /*
    [HttpGet("pdf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPdf(
        [FromServices] IGenerateBillingsPdfUseCase useCase,
        )
    */

}
