using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using CashFlow.Infrastructure.Extensions;
using CashFlow.Infrastructure.Security.Tokens;
using CashFlow.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    //O this AQUI USADO,FAZ COM QUE NÃO SEJA NECESSÁRIO EXPLICITAR
    //O PARÂMETRO services NA CHAMADA DOS MÉTODOS
    //JÁ QUE USA O VALOR DELE VINDO DA CLASSE ONDE FOR CHAMADA
    //NESSE CASO É USADO EM PROGRAM
    public static void AddInfrastructure(this IServiceCollection services, 
                                              IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();

        AddToken(services, configuration);
        AddRepositories(services);
        
        //CONFIGURAÇÃO DA INJEÇÃO DE DEPENDÊNCIA PARA DbContext
        //SOMENTE SE NÃO FOR O AMBIENTE DE TEST
        if(configuration.IsTestEnviroment() == false)
        {
            AddDbContext(services, configuration);
        }
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var siginKey = configuration.GetValue<string>("Settings:Jwt:SigninKey");

        //CONFIGURANDO A INJEÇÃO DE DEPENDÊNCIA PARA QUE ELA SAIBA QUE, EM PROGRAM, AO USAR UM IAccessTokenGenerator
        //SEJA INSTANCIADO UM JwtTokenGenerator CUJO CONSTRUTOR TENHA OS VALORES REPASSADOR ABAIXO
        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, siginKey!));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        //INJEÇÃO DE PEDENDÊNCIA
        //EM QUALQUER LUGAR DO CÓDIGO, AO USAR A PROPRIEDADE [FromServices] OU
        //UM OBJETO IExpensesWriteRepository / IExpensesReadOnlyRepository
        //É INJETADA UMA INSTÂNCIA, QUE INDICADA COMO IExpensesWriteRepository / IExpensesReadOnlyRepository,
        //INSTANCIA UM TIPO ExpensesRepository
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesUpateOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }

    //INJEÇÃO DE DEPENDÊNCIA ESPECÍFICA PARA CONEXÃO COM BASE DE DADOS
    //NÃO USA SINGLETON, SCOPED OU TRANSIENT, MAS SIM AddDbContext
    //PARA CONECTAR A CLASSE RESPONSÁVEL PELA BASE DE DADOS
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        //INJEÇÃO PARA DbContextOptions USADO EM CashFlowDbContext - NO CONSTRUTOR
        //LEITURA DA connectionString de appSettings.Development.json
        
        var connectionString = configuration.GetConnectionString("Connection");
        //var serverVersion = new MySqlServerVersion(new Version(8, 0, 46));
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        //optionsBuilder.UseMySql(connectionString, serverVersion);
        services.AddDbContext<CashFlowDbContext>(config => 
                                        config.UseMySql(connectionString, serverVersion));
    }


}
