using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Entities;
using Moq;

namespace CommonTestUtilities.Repositories;
public class UserUpdateOnlyRepositoryBuilder
{
    public static IUserUpdateOnlyRepository Build(User user)
    {
        var mock = new Mock<IUserUpdateOnlyRepository>();
        mock.Setup(respository => respository.GetById(user.Id)).ReturnsAsync(user);
        return mock.Object;
    }


}
