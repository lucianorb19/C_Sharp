using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories;
public class UserReadOnlyRepositoryBuilder
{

    private readonly Mock<IUserReadOnlyRepository> _repository;

    public UserReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IUserReadOnlyRepository>();
    }

    public IUserReadOnlyRepository Build()
    {
        return _repository.Object;
    }

    //FUNÇÃO QUE CONFIGURA O MOCK PARA RETORNAR TRUE NA CHAMADA DA FUNÇÃO
    //IReadOnlyRepository.ExistActiveUserWithEmail (O QUE GERA LANÇAMENTO DE EXCEÇÃO)
    public void ExistActiveUserWithEmail(string email)
    {
        _repository.Setup(userReadOnly => userReadOnly.ExistActiveUserWithEmail(email))
                                                      .ReturnsAsync(true);
    }

    //FUNÇÃO QUE CONFIGURA O MOCK PARA RETORNAR O USUÁRIO PASSADO COMO PARAMETRO SE
    //A FUNÇÃO IReadOnlyRepository.GetUserByEmail RECEBER O EMAIL DESTE MESMO USUÁRIO
    //O QUE É ÚTIL PARA O TESTE DO CASO DE SUCESSO
    //*USA TIPO DE RETORNO UserReadOnlyRepositoryBuilder E return this PARA QUE, NA SUA
    //CHAMADA EM DoLoginUseCaseTest.CreateUseCase, POSSAMOS ENCADEAR TODA CHAMADA
    public UserReadOnlyRepositoryBuilder GetUserByEmail(User user)
    {
        _repository.Setup(userRepository => userRepository.GetUserByEmail(user.Email))
                   .ReturnsAsync(user);

        return this;
    }
}
