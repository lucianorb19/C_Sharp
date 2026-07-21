using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Users.Register;
public class RegisterUserUseCaseTest
{

    [Fact]
    public async Task Sucess_UserRegisterWithValidFields()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase();


        var result = await useCase.Execute(request);


        result.Should().NotBeNull();//RESPOSTA NÃO PODE SER NULA
        // O NOME NO RESULT DEVE SER O NOME VINDO DA REQUEST, APÓS O AUTOMAPPER PROCESSAR
        result.Name.Should().Be(request.Name);
        result.Token.Should().NotBeNullOrWhiteSpace();

    }

    [Fact]
    public async Task Error_Name_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        var useCase = CreateUseCase();


        //FUNÇÃO ARMAZENADA NA VARIÁVEL act
        //FEITO ASSIM PQ O RESULTADO DE useCase.Execute, NO CASO DE FALHA,
        //É UMA EXCEÇÃO (throw new ErrorOnValidationException)
        var act = async() => await useCase.Execute(request);

        //EXCEÇÃO ASSÍNCRONA DO TIPO ErrorOnValidationException DEVE SER LANÇADA
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        //RESULTADO DEVE CONTER UM ÚNICO ERRO E COM MENSAGEM ResourceErrorMessage.NAME_EMPTY 
        result.Where(exception => exception.GetErrors().Count == 1 &&
                     exception.GetErrors().Contains(ResourceErrorMessages.NAME_EMPTY));


        /*
         async() => await useCase.Execute(request);

        É O MESMO QUE
            
            var act = Act;

            private async Task Act()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;
            var useCase = CreateUseCase();
            await useCase.Execute(request);
        }
         */
    }

    [Fact]
    public async Task Error_Email_Already_Exists()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase(request.Email);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(exception => exception.GetErrors().Count == 1 &&
                     exception.GetErrors().Contains(ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
    }


    //FUNÇÃO AUXILIAR
    private RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var mapper = MapperBuilder.Build();//IMPLEMENTAÇÃO REAL
        var unitOfWork = UnityOfWorkBuilder.Build(); //MOCK SIMPLES PQ RETORNO É VOID/TASK
        var writeRespository = UserWriteOnlyRepositoryBuilder.Build();//MOCK SIMPLES....
        var passwordEncripter = PasswordEncripterBuilder.Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder();

        //SE HOUVER EMAIL NA CHAMADA DE CreateUseCase
        if(string.IsNullOrWhiteSpace(email) == false)
        {
            //FUNÇÃO QUE CONFIGURA O MOCK PARA LANÇAR EXCEÇÃO
            readRepository.ExistActiveUserWithEmail(email);
        }
        //SE NÃO, MOCK NÃO LANÇA EXCEÇÃO (RELACIONADA A FUNÇÃO IReadOnlyRepository.ExistActiveUserWithEmail)

        return new RegisterUserUseCase(mapper, passwordEncripter, readRepository.Build(), 
                                       writeRespository, unitOfWork, tokenGenerator);
    }



}
