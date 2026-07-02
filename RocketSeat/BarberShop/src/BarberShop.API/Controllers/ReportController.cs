using BarberShop.Application.UseCases.Billings.Reports.Excel;
using BarberShop.Application.UseCases.Billings.Reports.Pdf;
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
    public async Task<IActionResult> GetExcelMonth(
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
    public async Task<IActionResult> GetExcelWeek(
        [FromServices] IGenerateWeekBillingsReportExcelUseCase useCase)
    {
        byte[] file = await useCase.Execute();
        if (file.Length > 0) return File(file, MediaTypeNames.Application.Octet, "reportWeek.xlsx");
        return NoContent();
    }


    
    [HttpGet("pdf/month")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPdfMonth(
        [FromServices] IGenerateMonthBillingsReportPdfUseCase useCase,
        [FromQuery] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);
        if (file.Length > 0) return File(file, MediaTypeNames.Application.Pdf, "reportMonth.pdf");
        return NoContent();
    }

    [HttpGet("pdf/week")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPdfWeek(
        [FromServices] IGenerateWeekBillingsReportPdfUseCase useCase)
    {
        byte[] file = await useCase.Execute();
        if (file.Length > 0) return File(file, MediaTypeNames.Application.Octet, "reportWeek.pdf");
        return NoContent();
    }


}
