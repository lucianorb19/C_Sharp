using CashFlow.API.Filters;
using CashFlow.API.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

//INJEÇÃO DE DEPENDÊNCIA
//MÉTODO DE EXTENSÃO DO PROJETO Infrastructure CRIADO PARA builder.Services
builder.Services.AddInfrastructure(builder.Configuration);
//DO PROJETO APPLICATION
builder.Services.AddApplication();

//builder.Services.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//USO DO MIDDLEWARE DE LINGUAGEM (EN, PT-BR) ENTRE SOLICITAÇÃO->MIDDLEWARE->REQUISIÇÃO
app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//EXECUTA AS MIGRATIONS SEMPRE QUE A APLICAÇÃO FOR EXECUTADA
//RETIRA A NECESSIDADE DE EXECUTAR NO CMD 'dotnet ef database update...'
await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();
    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
}
