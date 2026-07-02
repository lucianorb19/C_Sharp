namespace BarberShop.Application.UseCases.Billings.Reports.Pdf;
public interface IGenerateWeekBillingsReportPdfUseCase
{
    Task<byte[]> Execute();
}
