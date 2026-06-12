using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        //1ª MANEIRA DE USAR FAKER
        /*
        var faker = new Faker();
        var request = new RequestRegisterExpenseJson
        {
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Date = faker.Date.Past(),
            PaymentType = faker.PickRandom<PaymentType>(),
            Amount = faker.Random.Decimal(),

        };
        return request;
        */

        //2ª MANEIRA DE USAR FAKER
        return new Faker<RequestExpenseJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal());
    }
}
