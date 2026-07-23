using CashFlow.Application.UseCases.Login.DoLogin;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Login.DoLogin;
public class DoLoginUseCaseTest
{

    [Fact]
    public async Task Sucess_LoginWithValidFields()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;
        var useCase = CreateUseCase(user, request.Password);

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(user.Name);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

   
    [Fact]
    public async Task Error_UserNotFound()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        var useCase = CreateUseCase(user, request.Password);


        var act = async() => await useCase.Execute(request);


        var result = await act.Should().ThrowAsync<InvalidLoginException>();
        result.Where(exception => exception.GetErrors().Count == 1 &&
                     exception.GetErrors().Contains(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID));

    }
    
    
    [Fact]
    public async Task Error_PasswordNotMatch()
    {

        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;
        var useCase = CreateUseCase(user);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<InvalidLoginException>();
        result.Where(exception => exception.GetErrors().Count == 1 &&
                     exception.GetErrors().Contains(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID));

    }
    

    //FUNÇÃO AUXILIAR
    public DoLoginUseCase CreateUseCase(CashFlow.Domain.Entities.User user, string? password = null)
    {
        var passwordEncripter = new PasswordEncrypterBuilder().Verify(password).Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

        return new DoLoginUseCase(readRepository, passwordEncripter, tokenGenerator);
    }
}
