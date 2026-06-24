using BarberShop.Communication.Enums;

namespace BarberShop.Communication.Responses;
public class ResponseBillingJson
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public string BarberName { get; set; } 
    public string ClientName { get; set; }
    public string ServiceName { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Status Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
