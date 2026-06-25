using BarberShop.Communication.Enums;
using BarberShop.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests;
public class RequestBillingJsonBuilder
{
    public static RequestBillingJson Build()
    {
        var dataOntem = DateTime.Now.AddDays(-1);
        var dataAmanha = DateTime.Now.AddDays(1);

        
        var faker = new Faker();
        var request = new RequestBillingJson
        {
            Date = faker.Date.Between(dataOntem, dataAmanha),
            BarberName = faker.Name.FullName(),
            ClientName = faker.Name.FullName(),
            ServiceName = faker.PickRandom("Corte","Barba","Corte e barba"),
            Status = faker.PickRandomWithout<Status>(0),//NÃO SERÁ TESTADO PEDIDO CANCELADO
            Amount = faker.Random.Decimal(min:10, max:1000),
            PaymentMethod = faker.PickRandom<PaymentMethod>(),
            Notes = faker.Commerce.ProductDescription(),
            CreatedAt = faker.Date.Recent(),
            UpdatedAt = faker.Date.Recent()
        };
        return request;
        
        /*
        return new Faker<RequestBillingJson>()
            .RuleFor(request => request.Date, faker => faker.Date.Between(dataOntem, dataAmanha))
            .RuleFor(request => request.BarberName, faker => faker.Name.FullName())
            .RuleFor(request => request.ClientName, faker => faker.Name.FullName())
            .RuleFor(request => request.ServiceName, faker => faker.PickRandom("Corte",
                                                                               "Barba",
                                                                               "Corte e barba"))
            .RuleFor(request => request.Amount, faker => faker.Random.Decimal())
            .RuleFor(request => request.PaymentMethod, faker => faker.PickRandom<PaymentMethod>())
            .RuleFor(request => request.Status, faker => faker.PickRandom<Status>())
            .RuleFor(request => request.Notes, faker => faker.Commerce.ProductDescription())
            .RuleFor(request => request.CreatedAt, faker => faker.Date.Recent())
            .RuleFor(request => request.UpdatedAt, faker => faker.Date.Recent());
        */
    }
}
