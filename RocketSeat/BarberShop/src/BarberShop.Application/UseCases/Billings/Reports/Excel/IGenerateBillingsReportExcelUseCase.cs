namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public interface IGenerateBillingsReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
