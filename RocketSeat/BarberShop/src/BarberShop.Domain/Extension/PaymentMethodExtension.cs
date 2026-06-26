using BarberShop.Domain.Enums;
using BarberShop.Domain.Reports;

namespace BarberShop.Domain.Extension;
public static class PaymentMethodExtension
{
    public static string PaymentMethodToString(this PaymentMethod paymentMethod)
    {
        return paymentMethod switch
        {
            PaymentMethod.Cash => ResourceReportGenerationPaymentMethod.CASH,
            PaymentMethod.CreditCard => ResourceReportGenerationPaymentMethod.CREDIT_CARD,
            PaymentMethod.DebitCard => ResourceReportGenerationPaymentMethod.DEBIT_CARD,
            PaymentMethod.EletronicTransfer => ResourceReportGenerationPaymentMethod.ELETRONIC_TRANSFER,
            PaymentMethod.Pix => ResourceReportGenerationPaymentMethod.PIX,
            _ => string.Empty
        };
    }
}
