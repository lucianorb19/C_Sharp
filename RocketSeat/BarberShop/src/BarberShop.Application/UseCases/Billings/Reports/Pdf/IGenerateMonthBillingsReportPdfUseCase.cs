namespace BarberShop.Application.UseCases.Billings.Reports.Pdf;
public interface IGenerateMonthBillingsReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
