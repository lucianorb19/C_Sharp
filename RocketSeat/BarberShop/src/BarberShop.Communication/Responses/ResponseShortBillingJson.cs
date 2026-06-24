namespace BarberShop.Communication.Responses;
public class ResponseShortBillingJson
{
    public string ClientName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
