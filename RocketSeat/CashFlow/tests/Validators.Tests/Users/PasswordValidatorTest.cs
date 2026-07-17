using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users;
public class PasswordValidatorTest
{

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]//SENHAS VAZIA
    [InlineData("a")]
    [InlineData("aaaaaaa")]//SENHAS COM TAMANHOS MENORES QUE 8
    [InlineData("aaaaaaaa")] //SENHA SEM MAIÚSCULO
    [InlineData("AAAAAAAA")] //SENHA SEM MINÚSCULO
    [InlineData("Aaaaaaaa")]//SEM NÚMERO
    [InlineData("Aaaaaaaa1")]//SEM CARACTERE ESPECIAL

    public void Error_Password_Invalid(string password)
    {

        var validator = new PasswordValidator<RequestRegisterUserJson>();

        var result = validator
            .IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), 
                                                                    password);

        result.Should().BeFalse();
    }

}
