using BarberShop.Application.UseCases.Billings.Reports.Pdf.Colors;
using BarberShop.Application.UseCases.Billings.Reports.Pdf.Fonts;
using BarberShop.Domain.Reports;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Globalization;
using System.Reflection;

namespace BarberShop.Application.UseCases.Billings.Reports.Pdf;
public static class PdfFunctions
{
    public static Document CreateDocument(DateOnly month)
    {
        var document = new Document();
        document.Info.Title = $"{ResourceReportGenerationMessages.SERVICE_NAME} {month.ToString("Y")}";
        document.Info.Author = "lucianorb19";

        //FONTE PADRÃO
        var styles = document.Styles["Normal"];
        styles!.Font.Name = FontHelper.DEFAULT_FONT;

        return document;
    }

    public static Section CreatePage(Document document)
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

    public static void CreateHeaderWithProfilePhotoAndName(Section page)
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

    public static void CreateTotalBillingsSection(Section page, DateOnly month, decimal totalBillings, string currencySymbol)
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

        paragraph.AddFormattedText($"{currencySymbol} {totalBillings.ToString(new CultureInfo("pt-BR"))} ",
                                   new Font
                                   {
                                       Name = FontHelper.BEBAS_NEUE_REGULAR,
                                       Size = 50
                                   });

    }

    public static Table CreateBillingTable(Section page)
    {
        var table = page.AddTable();

        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;
        return table;
    }

    public static void AddBillingTitle(Cell cell, string billingTitle)
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

    public static void AddHeaderForAmount(Cell cell)
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
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    public static byte[] RenderDocument(Document document)
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

    public static void SetStyleBaseForBillingInformation(Cell cell)
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

    public static void AddAmountForBilling(Cell cell, decimal amount, string currencySymbol)
    {
        cell.AddParagraph($"{amount} {currencySymbol}");
        cell.Format.Font = new Font
        {
            Name = FontHelper.ROBOTO_REGULAR,
            Size = 10,
            Color = ColorsHelper.BLACK
        };
        cell.Shading.Color = ColorsHelper.WHITE;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    public static void AddWhiteSpace(Table table)
    {
        var row = table.AddRow();
        row.Height = 30;
        row.Borders.Visible = false;
    }
}
