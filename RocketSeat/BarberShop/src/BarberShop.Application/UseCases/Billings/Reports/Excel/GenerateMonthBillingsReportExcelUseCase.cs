
using BarberShop.Domain.Entities;
using BarberShop.Domain.Extension;
using BarberShop.Domain.Reports;
using BarberShop.Domain.Repositories.Billings;
using ClosedXML.Excel;

namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public class GenerateMonthBillingsReportExcelUseCase : IGenerateMonthBillingsReportExcelUseCase
{
    private readonly IBillingsReadOnlyRepository _repository;
    private const string CURRENCY_SYMBOL = "R$";

    public GenerateMonthBillingsReportExcelUseCase(IBillingsReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var billings = await _repository.FilterByMonth(month);
        var totalBillings = billings.Sum(billing => billing.Amount);
        if (billings.Count == 0) return [];

        //using PARA GARANTIR QUE O USO DOS RECURSOS É INTERROMPIDO
        //AO FINAL DA OPERAÇÃO COM O ARQUIVO
        using var workBook = new XLWorkbook(); //CRIAÇÃO PLANILHA

        workBook.Author = "lucianorb19";
        workBook.Style.Font.FontSize = 12;
        workBook.Style.Font.FontName = "Times New Roman";

        //CRIAÇÃO ABA DA PLANILHA COM NOME SENDO "MES / ANO"
        var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

        ExcelFunctions.InsertHeader(workSheet, CURRENCY_SYMBOL);
        ExcelFunctions.InsertBody(workSheet, billings, totalBillings);
        workSheet.Columns().AdjustToContents();

        //ARQUIVO SALVO COMO ARRAY DE BYTES
        var file = new MemoryStream();
        workBook.SaveAs(file);
        return file.ToArray();
    }

    

    
}
