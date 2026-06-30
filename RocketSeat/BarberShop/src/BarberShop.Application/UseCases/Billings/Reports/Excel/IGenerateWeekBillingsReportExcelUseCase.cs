namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public interface IGenerateWeekBillingsReportExcelUseCase
{
    Task<byte[]> Execute();
}
