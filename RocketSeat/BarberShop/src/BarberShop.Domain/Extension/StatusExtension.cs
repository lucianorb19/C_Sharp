using BarberShop.Domain.Enums;
using BarberShop.Domain.Reports;

namespace BarberShop.Domain.Extension;
public static class StatusExtension
{
    public static string StatusToString(this Status status)
    {
        return status switch
        {
            Status.Canceled => ResourceReportGenerationStatus.CACELED,
            Status.Paid => ResourceReportGenerationStatus.PAID,
            _ => string.Empty
        };
    }
}
