using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Infrastructure.DataAccess;
using CommonTestUtilities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Test.Resources;

namespace WebApi.Test;
public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public ExpenseIdentityManager Expense { get; private set; } = default!;
    public UserIdentityManager User_Team_Member { get; private set; } = default!;
    public UserIdentityManager User_Admin { get; private set; } = default!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //DEFINE QUE O TESTE DE INTEGRAÇÃO IRÁ USAR O ARQUIVO
        //appsettings.Test.json - AMBIENTE DE TESTE
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                //AMBIENTE DE TESTE CONFIGURADO PARA USAR BASE DE DADOS EM MEMÓRIA
                //PARA NÃO PERSISTIR RESULTADOS DAS OPERAÇÕES NA BASE DE DADOS CashFlowDb2
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                services.AddDbContext<CashFlowDbContext>(config =>
                {
                    config.UseInMemoryDatabase("InMemoryDbForTesting");
                    config.UseInternalServiceProvider(provider);
                });

                //CONFIGURAÇÃO PARA ACESSO AO CashFlowDbContext,IPasswordEncrypter e IAccessTokenGenerator
                //UTILIZANDO UMA SIMULAÇÃO DE ESCOPO, COMO SE FOSSE O ESCOPO DA REQUISIÇÃO HTTP
                //NUM CONTEXTO REAL
                var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<CashFlowDbContext>();
                var passwordEncrypter = scope.ServiceProvider
                                             .GetRequiredService<IPasswordEncripter>();
                var accessTokenGenerator = scope.ServiceProvider
                                             .GetRequiredService<IAccessTokenGenerator>();


                StartDatabase(dbContext, passwordEncrypter, accessTokenGenerator);

            });
    }

    //FUNÇÃO QUE INICIA A BASE DE DADOS EM MEMÓRIA
    private void StartDatabase(CashFlowDbContext dbContext, 
                               IPasswordEncripter passwordEncrypter,
                               IAccessTokenGenerator accessTokenGenerator)
    {
        var user = AddUserTeamMember(dbContext, passwordEncrypter, accessTokenGenerator);
        AddExpenses(dbContext, user);
        dbContext.SaveChanges();
    }

    //FUNÇÕES AUXILIARES
    private User AddUserTeamMember(CashFlowDbContext dbContext, 
                          IPasswordEncripter passwordEncrypter,
                          IAccessTokenGenerator accessTokenGenerator)
    {
        var user = UserBuilder.Build();
        var passwordReal = user.Password; //SENHA SEM CRIPTOGRAFIA SALVA ANTES DE REGISTRAR NO BANCO
                                        //VAI SER NECESSÁRIO PARA TESTE DE SUCESSO
        user.Password = passwordEncrypter.Encrypt(user.Password);//SENHA CRIPTOGRAFADA REGISTRADA
        dbContext.Add(user);

        var token = accessTokenGenerator.Generate(user);

        User_Team_Member = new UserIdentityManager(user, passwordReal, token);
        return user;
    }

    //FUNÇÃO QUE ADICIONA UMA DESPESA, PARA GARANTIR O SUCESSO NO TESTE DE INTEGRAÇÃO - GetAllExpenses
    private void AddExpenses(CashFlowDbContext dbContext, User user)
    {
        var expense = ExpenseBuilder.Build(user);
        dbContext.Expenses.Add(expense);
        Expense = new ExpenseIdentityManager(expense);
    }

}
