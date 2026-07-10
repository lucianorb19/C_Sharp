using CashFlow.API.Filters;
using CashFlow.API.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;
using CashFlow.Infrastructure.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//CONFIGURAÇÃO DO SWAGGER PARA MOSTRAR NA SUA INTERFACE A OPÇÃO DE ADICIONAR O JWT
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = @"JWT Authorization header using the Bearer scheme.
                       Enter 'Bearer' [space] and then your token in the text input below.
                       Example: 'Bearer 123456mytoken'",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }   
    });

});

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

//INJEÇÃO DE DEPENDÊNCIA
//MÉTODO DE EXTENSÃO DO PROJETO Infrastructure CRIADO PARA builder.Services
builder.Services.AddInfrastructure(builder.Configuration);
//DO PROJETO APPLICATION
builder.Services.AddApplication();

//USO DE AUTORIZAÇÃO E AUTENTICAÇÃO COM JWT
var signInKey = builder.Configuration.GetValue<string>("Settings:Jwt:SigninKey");
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = new TimeSpan(0),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey!))
    };
});

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

app.UseAuthentication();
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
