
using BarberShop.Domain.Repositories.Billings;
using ClosedXML.Excel;

namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public class GenerateWeekBillingsReportExcelUseCase : IGenerateWeekBillingsReportExcelUseCase
{
    private readonly IBillingsReadOnlyRepository _repository;
    private const string CURRENCY_SYMBOL = "R$";

    public GenerateWeekBillingsReportExcelUseCase(IBillingsReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute()
    {
        var billings = await _repository.FilterByWeek();
        var totalBillings = billings.Sum(billing => billing.Amount);
        if (billings.Count == 0) return [];

        using var workBook = new XLWorkbook(); //CRIAÇÃO PLANILHA

        workBook.Author = "lucianorb19";
        workBook.Style.Font.FontSize = 12;
        workBook.Style.Font.FontName = "Times New Roman";

        //CRIAÇÃO ABA DA PLANILHA COM NOME SENDO "DD/MM/YYYY"
        var workSheet = workBook.Worksheets.Add(DateTime.Today.ToString("d"));

        ExcelFunctions.InsertHeader(workSheet, CURRENCY_SYMBOL);
        ExcelFunctions.InsertBody(workSheet, billings, totalBillings);
        workSheet.Columns().AdjustToContents();

        //ARQUIVO SALVO COMO ARRAY DE BYTES
        var file = new MemoryStream();
        workBook.SaveAs(file);
        return file.ToArray();
    }
}
