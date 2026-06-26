
using BarberShop.Domain.Extension;
using BarberShop.Domain.Reports;
using BarberShop.Domain.Repositories.Billings;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Runtime.CompilerServices;

namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public class GenerateBillingsReportExcelUseCase : IGenerateBillingsReportExcelUseCase
{
    private readonly IBillingsReadOnlyRepository _repository;
    private const string CURRENCY_SYMBOL = "R$";

    public GenerateBillingsReportExcelUseCase(IBillingsReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var billings = await _repository.FilterByMonth(month);
        if (billings.Count == 0) return [];

        //using PARA GARANTIR QUE O USO DOS RECURSOS É INTERROMPIDO
        //AO FINAL DA OPERAÇÃO COM O ARQUIVO
        using var workBook = new XLWorkbook(); //CRIAÇÃO PLANILHA

        workBook.Author = "lucianorb19";
        workBook.Style.Font.FontSize = 12;
        workBook.Style.Font.FontName = "Times New Roman";

        //CRIAÇÃO ABA DA PLANILHA COM NOME SENDO "MES / ANO"
        var workSheet = workBook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(workSheet);

        //CORPO
        var linha = 2;
        foreach(var billing in billings)
        {
            workSheet.Cell($"A{linha}").Value = billing.ServiceName;
            workSheet.Cell($"B{linha}").Value = billing.ClientName;
            workSheet.Cell($"C{linha}").Value = billing.BarberName;
            workSheet.Cell($"D{linha}").Value = billing.Amount;
            workSheet.Cell($"E{linha}").Value = billing.Date;
            workSheet.Cell($"F{linha}").Value = billing.PaymentMethod.PaymentMethodToString();
            //CONTINUE




        }

    }

    private void InsertHeader(IXLWorksheet workSheet)
    {
        workSheet.Cells("A1:H1").Style.Font.Bold = true;
        workSheet.Cells("A1:H1").Style.Fill.BackgroundColor = XLColor.FromHtml("#FAEBD7");
        workSheet.Cells("A1:C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        workSheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        workSheet.Cells("E1:H1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        workSheet.Cell("J1").Style.Font.Bold = true;
        workSheet.Cell("J1").Style.Fill.BackgroundColor = XLColor.FromHtml("#FAEBD7");
        workSheet.Cell("J1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        workSheet.Cell("A1").Value = ResourceReportGenerationMessages.SERVICE_NAME;
        workSheet.Cell("B1").Value = ResourceReportGenerationMessages.CLIENT_NAME;
        workSheet.Cell("C1").Value = ResourceReportGenerationMessages.BARBER_NAME;
        workSheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
        workSheet.Cell("E1").Value = ResourceReportGenerationMessages.DATE;
        workSheet.Cell("F1").Value = ResourceReportGenerationMessages.PAYMENT_METHOD;
        workSheet.Cell("G1").Value = ResourceReportGenerationMessages.STATUS;
        workSheet.Cell("H1").Value = ResourceReportGenerationMessages.NOTES;
        workSheet.Cell("J1").Value = ResourceReportGenerationMessages.TOTAL;
    }
}
