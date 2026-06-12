using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Sucess_ExpenseRegisterWithValidFieldsIsValid()
    {
        //ARRANGE
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        

        //ACT
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
    [InlineData("      ")]
    [InlineData(null)]
    public void ErrorEmptyOrWhiteSpaceOrNullTytle(string emptyTitle)
    {
        //ARRANGE
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = emptyTitle;
        
        //ACT
        var result = validator.Validate(request);

        //ASSERT COM FLUENTASSERTION
        result.IsValid.Should().BeFalse();//TEM QUE GERAR ERRO
        //TEM QUE SER SOMENTE UM ERRO, COM A STRING ESPECÍFICA QUE GERAMOS EM RESOURCES
        result.Errors.Should().ContainSingle()
              .And.Contain(erro => erro.ErrorMessage.Equals(
                     ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public void ErrorFutureExpenseDate()
    {
        //ARRANGE
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(2);

        //ACT
        var result = validator.Validate(request);

        //ASSERT COM FLUENTASSERTION
        result.IsValid.Should().BeFalse();//TEM QUE GERAR ERRO
        //TEM QUE SER SOMENTE UM ERRO, COM A STRING ESPECÍFICA QUE GERAMOS EM RESOURCES
        result.Errors.Should().ContainSingle()
              .And.Contain(erro => erro.ErrorMessage.Equals(
                     ResourceErrorMessages.EXPENSE_DATE_NOT_FUTURE));
    }

    [Fact]
    public void ErrorPaymentTypeNotAValidEnum()
    {
        //ARRANGE
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)8;

        //ACT
        var result = validator.Validate(request);

        //ASSERT COM FLUENTASSERTION
        result.IsValid.Should().BeFalse();//TEM QUE GERAR ERRO
        //TEM QUE SER SOMENTE UM ERRO, COM A STRING ESPECÍFICA QUE GERAMOS EM RESOURCES
        result.Errors.Should().ContainSingle()
              .And.Contain(erro => erro.ErrorMessage.Equals(
                     ResourceErrorMessages.EXPENSE_TYPE_NOT_VALID));
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-40)]
    public void ErrorAmountLessThanOrEqualToZero(decimal testAmount)
    {
        //ARRANGE
        var validator = new ExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = testAmount;

        //ACT
        var result = validator.Validate(request);

        //ASSERT COM FLUENTASSERTION
        result.IsValid.Should().BeFalse();//TEM QUE GERAR ERRO
        //TEM QUE SER SOMENTE UM ERRO, COM A STRING ESPECÍFICA QUE GERAMOS EM RESOURCES
        result.Errors.Should().ContainSingle()
              .And.Contain(erro => erro.ErrorMessage.Equals(
                     ResourceErrorMessages.AMOUNT_GREATER_THAN_ZERO));
    }




}
