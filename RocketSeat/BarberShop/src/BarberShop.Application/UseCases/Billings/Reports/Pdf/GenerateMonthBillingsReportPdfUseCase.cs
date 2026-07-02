
using BarberShop.Application.UseCases.Billings.Reports.Pdf.Colors;
using BarberShop.Application.UseCases.Billings.Reports.Pdf.Fonts;
using BarberShop.Domain.Extension;
using BarberShop.Domain.Repositories.Billings;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp.Fonts;

namespace BarberShop.Application.UseCases.Billings.Reports.Pdf;
public class GenerateMonthBillingsReportPdfUseCase : IGenerateMonthBillingsReportPdfUseCase
{
    private const string CURRENCY_SYMBOL = "R$";
    private const int HEIGHT_ROW_BILLING_TABLE = 25;
    private readonly IBillingsReadOnlyRepository _repository;

    public GenerateMonthBillingsReportPdfUseCase(IBillingsReadOnlyRepository repository)
    {
        _repository = repository;
        GlobalFontSettings.FontResolver = new BillingsReportFontResolver();
    }


    public async Task<byte[]> Execute(DateOnly month)
    {
        var billings = await _repository.FilterByMonth(month);
        var totalBillings = billings.Where(billing => billing.Status == Domain.Enums.Status.Paid)
                                    .Sum(billing => billing.Amount);
        if (billings.Count == 0) return [];

        var document = PdfFunctions.CreateDocument(month);
        var page = PdfFunctions.CreatePage(document);
        PdfFunctions.CreateHeaderWithProfilePhotoAndName(page);
        PdfFunctions.CreateTotalBillingsSection(page, month, totalBillings, CURRENCY_SYMBOL);

        foreach(var billing in billings)
        {
            var table = PdfFunctions.CreateBillingTable(page);

            //CABEÇALHO TABELA
            var row = table.AddRow();
            row.Height = HEIGHT_ROW_BILLING_TABLE;
            PdfFunctions.AddBillingTitle(row.Cells[0], $"{billing.ServiceName}-{billing.ClientName}");
            PdfFunctions.AddHeaderForAmount(row.Cells[3]);

            //SEGUNDA LINHA - INFORMAÇÕES E VALOR
            row = table.AddRow();
            row.Height = HEIGHT_ROW_BILLING_TABLE;
            //CÉLULA DATA
            row.Cells[0].AddParagraph(billing.Date.ToString("D"));
            PdfFunctions.SetStyleBaseForBillingInformation(row.Cells[0]);
            row.Cells[0].Format.LeftIndent = 20;

            //CÉLULA HORA
            row.Cells[1].AddParagraph(billing.Date.ToString("t"));
            PdfFunctions.SetStyleBaseForBillingInformation(row.Cells[1]);

            //CÉLULA MÉTODO PAGAMENTO
            row.Cells[2].AddParagraph(billing.PaymentMethod.PaymentMethodToString());
            PdfFunctions.SetStyleBaseForBillingInformation(row.Cells[2]);

            //CÉLULA VALOR
            PdfFunctions.AddAmountForBilling(row.Cells[3], billing.Amount, CURRENCY_SYMBOL);

            //TERCEIRA LINHA - OBSERVAÇÃO
            if(string.IsNullOrWhiteSpace(billing.Notes) == false)
            {
                var notesRow = table.AddRow();
                notesRow.Cells[0].AddParagraph(billing.Notes);
                notesRow.Height = HEIGHT_ROW_BILLING_TABLE;
                notesRow.Cells[0].Format.Font = new Font
                {
                    Name = FontHelper.ROBOTO_REGULAR,
                    Size = 10,
                    Color = ColorsHelper.DARKER_GREY
                };
                notesRow.Cells[0].Shading.Color = ColorsHelper.LIGHT_GREY;
                notesRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                notesRow.Cells[0].MergeRight = 2;
                notesRow.Cells[0].Format.LeftIndent = 20;

                //SEGUNDA LINHA, CÉLULA COM VALOR SE UNE COM CÉLULA ABAIXO
                //ISSO SIGNIFICA QUE NAS DESPESAS COM DESCRIÇÃO, O VALOR FICA
                //CENTRALIZADO VERTICALMENTE COM AS ÚLTIMAS DUAS LINHAS
                row.Cells[3].MergeDown = 1;
            }
            PdfFunctions.AddWhiteSpace(table);
        }
        return PdfFunctions.RenderDocument(document);
    }
}
