using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;

namespace CashFlow.Domain.Extensions;
public static class PaymentTypeExpensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourceReportGenerationPaymentType.CASH,
            PaymentType.CreditCard => ResourceReportGenerationPaymentType.CREDIT_CARD,
            PaymentType.DebitCard => ResourceReportGenerationPaymentType.DEBIT_CARD,
            PaymentType.EletronicTransfer => ResourceReportGenerationPaymentType.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}
