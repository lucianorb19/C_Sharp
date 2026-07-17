using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Users.Register;
public class RegisterUserValidatorTest
{


    [Fact]
    public void Sucess_UserRegisterWithValidFields()
    {
        //ARRANGE
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();

        //ACT
        var result = validator.Validate(request);

        //ASSERT
        result.IsValid.Should().BeTrue();
    }


    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Error_Name_Empty(string name)
    {
        
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = name;

        
        var result = validator.Validate(request);

        
        result.IsValid.Should().BeFalse();
        result.Errors.Should()
                     .ContainSingle()
                     .And.Contain(erro => erro.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
          
    }

    
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Error_Email_Empty(string email)
    {

        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = email;


        var result = validator.Validate(request);


        result.IsValid.Should().BeFalse();
        result.Errors.Should()
                   .ContainSingle()
                   .And.Contain(erro => erro.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));
    }

    [Fact]
    public void Error_Email_Invalid()
    {

        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = "lucianogmail.com";


        var result = validator.Validate(request);


        result.IsValid.Should().BeFalse();
        result.Errors.Should()
                   .ContainSingle()
                   .And.Contain(erro => erro.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID));
    }


    [Fact]
    public void Error_Password_Empty()
    {

        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = string.Empty;


        var result = validator.Validate(request);


        result.IsValid.Should().BeFalse();
        result.Errors.Should()
                   .ContainSingle()
                   .And.Contain(erro => erro.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PASSWORD));
    }

}
