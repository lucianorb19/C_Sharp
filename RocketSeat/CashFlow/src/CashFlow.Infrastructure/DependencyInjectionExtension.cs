using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    //O this AQUI USADO, SERVE PARA QUE NÃO SEJA NECESSÁRIO EXPLICITAR
    //O PARÂMETRO services NA CHAMADA DO MÉTODO
    public static void AddInfrastructure(this IServiceCollection services)
    {
        //INJEÇÃO DE PEDENDÊNCIA
        //EM QUALQUER LUGAR DO CÓDIGO, AO USAR A PROPRIEDADE [FromServices]
        //É INJETADA UMA INSTÂNCIA, QUE INDICADA COMO IExpensesRepository,
        //INSTANCIA UM TIPO ExpensesRepository
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }
}
