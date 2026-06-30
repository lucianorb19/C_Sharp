using BarberShop.Domain.Entities;
using BarberShop.Domain.Extension;
using BarberShop.Domain.Reports;
using ClosedXML.Excel;

namespace BarberShop.Application.UseCases.Billings.Reports.Excel;
public static class ExcelFunctions
{
    public static void InsertHeader(IXLWorksheet workSheet, string currencySymbol)
    {
        workSheet.Cells("A1:H1").Style.Font.Bold = true;
        workSheet.Cells("A1:H1").Style.Fill.BackgroundColor = XLColor.FromHtml("#FAEBD7");
        workSheet.Cells("A1:C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        workSheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        workSheet.Cells("E1:H1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        workSheet.Cell("J1").Style.Font.Bold = true;
        workSheet.Cell("J1").Style.Fill.BackgroundColor = XLColor.FromHtml("#FAEBD7");
        workSheet.Cell("J1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        workSheet.Cell("A1").Value = ResourceReportGenerationMessages.SERVICE_NAME;
        workSheet.Cell("B1").Value = ResourceReportGenerationMessages.CLIENT_NAME;
        workSheet.Cell("C1").Value = ResourceReportGenerationMessages.BARBER_NAME;
        workSheet.Cell("D1").Value = $"{ResourceReportGenerationMessages.AMOUNT} ({currencySymbol})";
        workSheet.Cell("E1").Value = ResourceReportGenerationMessages.DATE;
        workSheet.Cell("F1").Value = ResourceReportGenerationMessages.PAYMENT_METHOD;
        workSheet.Cell("G1").Value = ResourceReportGenerationMessages.STATUS;
        workSheet.Cell("H1").Value = ResourceReportGenerationMessages.NOTES;
        workSheet.Cell("J1").Value = ResourceReportGenerationMessages.TOTAL;
    }

    public static void InsertBody(IXLWorksheet workSheet, List<Billing> billings, decimal totalBillings)
    {
        var linha = 2;
        foreach (var billing in billings)
        {
            workSheet.Cell($"A{linha}").Value = billing.ServiceName;
            workSheet.Cell($"B{linha}").Value = billing.ClientName;
            workSheet.Cell($"C{linha}").Value = billing.BarberName;
            workSheet.Cell($"D{linha}").Value = billing.Amount;
            workSheet.Cell($"D{linha}").Style.NumberFormat.Format = $"#,##0.00";
            workSheet.Cell($"E{linha}").Value = billing.Date;
            workSheet.Cell($"F{linha}").Value = billing.PaymentMethod.PaymentMethodToString();
            workSheet.Cell($"G{linha}").Value = billing.Status.StatusToString();
            workSheet.Cell($"H{linha}").Value = billing.Notes;
            linha++;
        }
        workSheet.Cell($"J2").Value = totalBillings;
    }
}
