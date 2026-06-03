using CashFlow.API.Filters;
using CashFlow.API.Middleware;
using CashFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

//INJEÇÃO DE DEPENDÊNCIA
//MÉTODO DE EXTENSÃO DO PROJETO Infrastructure CRIADO PARA builder.Services
builder.Services.AddInfrastructure();

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

app.Run();
