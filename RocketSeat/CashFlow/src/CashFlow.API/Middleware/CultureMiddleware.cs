using System.Globalization;

namespace CashFlow.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        //LINGUAGEM DA REQUISIÇÃO EM INGLÊS POR PADRÃO, CASO NÃO SEJA DEFINIDA PELO HEADER
        var cultureInfo = new CultureInfo("en");

        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        //CASO SEJA DEFINIDA PELO HEADER E SEJA UMA LIGUAGEM SUPORTADA PELO .NET
        //PEGO ESSA INFORMAÇÃO DO HEADER E DEFINO EM cultureInfo
        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        if(string.IsNullOrWhiteSpace(requestedCulture) == false 
           && supportedLanguages.Exists(language => language.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        //O RESULTADO É PASSADO COMO LINGUAGEM ATUAL EM Cultureinfo
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);//CONTINUA O FLUXO ENTRE SOLICITAÇÃO -> MIDDLEWARE -> ENDPOINT
    }
}
