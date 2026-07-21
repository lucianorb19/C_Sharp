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
}
