using CashFlow.Application.UseCases.Users.ChangePassword;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace UseCases.Test.Users.ChangePassword;
public class ChangePasswordUseCaseTest
{

    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        var request = RequestChangePasswordJsonBuilder.Build();
        var useCase = CreateUseCase(user, request.Password);

        var act = async () => await useCase.Execute(request);

        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task ErrorNewPasswordEmpty()
    {
        var user = UserBuilder.Build();
        var request = RequestChangePasswordJsonBuilder.Build();
        request.NewPassword = string.Empty;
        var useCase = CreateUseCase(user, request.Password);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(erro => erro.GetErrors().Count == 1 &&
                     erro.GetErrors().Contains(ResourceErrorMessages.INVALID_PASSWORD));
    }

    [Fact]
    public async Task ErrorCurrentPasswordDifferent()
    {
        var user = UserBuilder.Build();
        var request = RequestChangePasswordJsonBuilder.Build();
        var useCase = CreateUseCase(user);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(erro => erro.GetErrors().Count == 1 &&
                     erro.GetErrors().Contains(ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
    }


    private static ChangePasswordUseCase CreateUseCase (User user, string? password = null)
    {
        var loggedUser = LoggedUserBuilder.Build(user);
        var userUpdateRespository = UserUpdateOnlyRepositoryBuilder.Build(user);
        var unitOfWork = UnityOfWorkBuilder.Build();
        var passwordEncripter = new PasswordEncrypterBuilder().Verify(password).Build();

        return new ChangePasswordUseCase(loggedUser, userUpdateRespository, unitOfWork, passwordEncripter);   
    }

}
