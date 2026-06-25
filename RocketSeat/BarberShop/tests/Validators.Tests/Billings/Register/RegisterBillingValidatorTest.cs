using BarberShop.Application.UseCases.Billings;
using BarberShop.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Billings.Register;
public class RegisterBillingValidatorTest
{
    [Fact]
    public void Sucess_BillingRegisterWithValidFields()
    {
        var validator = new BillingValidator();
        var request = RequestBillingJsonBuilder.Build();

        var result = validator.Validate(request);

        //ASSERT TRADICIONAL
        //Assert.True(result.IsValid);

        //ASSERT COM FLUENTASSERTION
        result.IsValid.Should().BeTrue();

        //COM O FLUENTASSERTION PAGO A PARTIR DA VERSÃO 8.0
        //UMA ALTERNATIVA É A BIBLIOTECA SHOULDLY
    }

    [Theory]
    [InlineData("")]
    [InlineData("         ")]
    [InlineData(null)]
    public void Error_EmptyOrWhiteSpaceOrNullBarberName(string barberName)
    {
        var validator = new BillingValidator();
        var request = RequestBillingJsonBuilder.Build();
        request.BarberName = barberName;


        var result = validator.Validate(request);


        result.IsValid.Should().BeFalse();

    }

    [Theory]
    [InlineData(1,false)]
    [InlineData(2,true)]
    [InlineData(80,true)]
    [InlineData(81,false)]
    public void Depends_BarberNameLengthBetween2And80(int barberNameLength, bool valid)
    {
        var validator = new BillingValidator();
        var request = RequestBillingJsonBuilder.Build();
        request.BarberName = new string('A', barberNameLength);

        var result = validator.Validate(request);

        result.IsValid.Should().Be(valid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-40)]
    public void ErrorAmountLessThanZero(decimal testAmount)
    {
        var validator = new BillingValidator();
        var request = RequestBillingJsonBuilder.Build();
        request.Amount = testAmount;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
    }

}
