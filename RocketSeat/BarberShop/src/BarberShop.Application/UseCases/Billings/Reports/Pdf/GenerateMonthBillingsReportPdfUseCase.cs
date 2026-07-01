
using BarberShop.Application.UseCases.Billings.Reports.Pdf.Colors;
using BarberShop.Application.UseCases.Billings.Reports.Pdf.Fonts;
using BarberShop.Domain.Extension;
using BarberShop.Domain.Reports;
using BarberShop.Domain.Repositories.Billings;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Globalization;
using System.Reflection;

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

        var document = CreateDocument(month);
        var page = CreatePage(document);
        CreateHeaderWithProfilePhotoAndName(page);
        CreateTotalBillingsSection(page, month, totalBillings);

        foreach(var billing in billings)
        {
            var table = CreateBillingTable(page);

            //CABEÇALHO TABELA
            var row = table.AddRow();
            row.Height = HEIGHT_ROW_BILLING_TABLE;
            AddBillingTitle(row.Cells[0], $"{billing.ServiceName}-{billing.ClientName}");
            AddHeaderForAmount(row.Cells[3]);

            //SEGUNDA LINHA - INFORMAÇÕES E VALOR
            row = table.AddRow();
            row.Height = HEIGHT_ROW_BILLING_TABLE;
            //CÉLULA DATA
            row.Cells[0].AddParagraph(billing.Date.ToString("D"));
            SetStyleBaseForBillingInformation(row.Cells[0]);
            row.Cells[0].Format.LeftIndent = 20;

            //CÉLULA HORA
            row.Cells[1].AddParagraph(billing.Date.ToString("t"));
            SetStyleBaseForBillingInformation(row.Cells[1]);

            //CÉLULA MÉTODO PAGAMENTO
            row.Cells[2].AddParagraph(billing.PaymentMethod.PaymentMethodToString());
            SetStyleBaseForBillingInformation(row.Cells[2]);

            //CÉLULA VALOR
            AddAmountForBilling(row.Cells[3], billing.Amount);

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

            AddWhiteSpace(table);
        }



        return RenderDocument(document);
    }


    //FUNÇÕES AUXILIARES
    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();
        document.Info.Title = $"{ResourceReportGenerationMessages.SERVICE_NAME} {month.ToString("Y")}";
        document.Info.Author = "lucianorb19";

        //FONTE PADRÃO
        var styles = document.Styles["Normal"];
        styles!.Font.Name = FontHelper.DEFAULT_FONT;

        return document;
    }

    private Section CreatePage(Document document)
    {
        var section = document.AddSection();
        section.PageSetup = document.DefaultPageSetup.Clone();

        section.PageSetup.PageFormat = PageFormat.A4;
        section.PageSetup.LeftMargin = 35;
        section.PageSetup.RightMargin = 35;
        section.PageSetup.TopMargin = 53;
        section.PageSetup.BottomMargin = 80;

        return section;
    }

    private void CreateHeaderWithProfilePhotoAndName(Section page)
    {
        //FOTO E MENSAGEM BOAS VINDAS
        var table = page.AddTable();
        table.AddColumn("150");
        table.AddColumn("150");

        var row = table.AddRow();
        var assembly = Assembly.GetExecutingAssembly();
        var directoryName = Path.GetDirectoryName(assembly.Location);
        var pathFile = Path.Combine(directoryName!, "Logo", "patinho2.png");

        row.Cells[0].AddImage(pathFile);
        row.Cells[1].AddParagraph($"BARBEARIA TESTE");
        row.Cells[1].Format.Font = new Font { Name = FontHelper.BEBAS_NEUE_REGULAR, Size = 25 };
        row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
    }

    private void CreateTotalBillingsSection(Section page, DateOnly month, decimal totalBillings)
    {
        var title = string.Format(ResourceReportGenerationMessages.TOTAL_EARNED_IN, month.ToString("Y"));
        var paragraph = page.AddParagraph();
        paragraph.Format.SpaceAfter = 40;
        paragraph.Format.SpaceBefore = 40;

        paragraph.AddFormattedText(title, new Font
        {
            Name = FontHelper.ROBOTO_MEDIUM,
            Size = 15
        });
        paragraph.AddLineBreak();

        paragraph.AddFormattedText($"{CURRENCY_SYMBOL} {totalBillings.ToString(new CultureInfo("pt-BR"))} ",
                                   new Font
                                   {
                                       Name = FontHelper.BEBAS_NEUE_REGULAR,
                                       Size = 50
                                   });

    }

    private Table CreateBillingTable(Section page)
    {
        var table = page.AddTable();

        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;
        return table;
    }

    private void AddBillingTitle(Cell cell, string billingTitle)
    {
        cell.AddParagraph(billingTitle);
        cell.Format.Font = new Font
        {
            Name = FontHelper.BEBAS_NEUE_REGULAR,
            Size = 15,
            Color = ColorsHelper.WHITE
        };
        cell.Shading.Color = ColorsHelper.DARK_GREEN;
        cell.VerticalAlignment = VerticalAlignment.Center;
        cell.MergeRight = 2;
        cell.Format.LeftIndent = 20;
    }

    private void AddHeaderForAmount(Cell cell)
    {
        //CÉLULA AMOUNT/VALOR
        cell.AddParagraph(ResourceReportGenerationMessages.AMOUNT);
        cell.Format.Font = new Font
        {
            Name = FontHelper.BEBAS_NEUE_REGULAR,
            Size = 15,
            Color = ColorsHelper.WHITE
        };
        cell.Shading.Color = ColorsHelper.LIGHT_GREEN;
        cell.VerticalAlignment= VerticalAlignment.Center;
    }

    private byte[] RenderDocument(Document document)
    {
        var renderer = new PdfDocumentRenderer
        {
            Document = document,
        };
        renderer.RenderDocument();

        using var file = new MemoryStream();
        renderer.PdfDocument.Save(file);

        return file.ToArray();
    }

    private void SetStyleBaseForBillingInformation(Cell cell)
    {
        cell.Format.Font = new Font
        {
            Name = FontHelper.ROBOTO_REGULAR,
            Size = 10,
            Color = ColorsHelper.BLACK
        };
        cell.Shading.Color = ColorsHelper.DARK_GREY;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddAmountForBilling(Cell cell, decimal amount)
    {
        cell.AddParagraph($"{amount} {CURRENCY_SYMBOL}");
        cell.Format.Font = new Font
        {
            Name = FontHelper.ROBOTO_REGULAR,
            Size = 10,
            Color = ColorsHelper.BLACK
        };
        cell.Shading.Color = ColorsHelper.WHITE;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddWhiteSpace(Table table)
    {
        var row = table.AddRow();
        row.Height = 30;
        row.Borders.Visible = false;
    }
}
