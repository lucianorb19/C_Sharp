namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public interface IGenerateMonthBillingsReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
