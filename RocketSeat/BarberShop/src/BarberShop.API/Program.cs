using BarberShop.API.Filters;
using BarberShop.API.Middleware;
using BarberShop.Application;
using BarberShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//FILTRO PARA EXCEÇÕES
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

//INJEÇÕES DE DEPENDÊNCIA COM MÉTODOS DE EXTENSÃO
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//MIDDLEWARE DE IDIOMAS
app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
