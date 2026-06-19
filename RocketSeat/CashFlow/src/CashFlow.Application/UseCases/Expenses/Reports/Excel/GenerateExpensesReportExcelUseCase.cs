using CashFlow.Domain.Extensions;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;
public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private const string CURRENCY_SYMBOL = "R$";

    public GenerateExpensesReportExcelUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _repository.FilterByMonth(month);
        if (expenses.Count() == 0) return [];

        //using PARA GARANTIR QUE O USO DOS RECURSOS É INTERROMPIDO
        //AO FINAL DA OPERAÇÃO COM O ARQUIVO
        using var workbook = new XLWorkbook();//CRIAÇÃO PLANILHA

        workbook.Author = "Luciano";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";

        //CRIAÇÃO ABA DA PLANILHA COM NOME SENDO "MES / ANO"
        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);//CABEÇALHO

        //CORPO
        var linha = 2;
        foreach(var expense in expenses)
        {
            worksheet.Cell($"A{linha}").Value = expense.Title;
            worksheet.Cell($"B{linha}").Value = expense.Date;
            worksheet.Cell($"C{linha}").Value = expense.PaymentType.PaymentTypeToString();

            worksheet.Cell($"D{linha}").Value = expense.Amount;
            worksheet.Cell($"D{linha}")
                .Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";

            worksheet.Cell($"E{linha}").Value = expense.Description;
            linha++;
        }

        worksheet.Columns().AdjustToContents();

        //ARQUIVO SALVO COMO ARRAY DE BYTES QUE REPRESENTAM A PLANILHA
        var file = new MemoryStream();
        workbook.SaveAs(file);
        return file.ToArray();
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cells("A1:E1").Style.Font.Bold = true;
        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");
        worksheet.Cells("A1:C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;
    }

}
