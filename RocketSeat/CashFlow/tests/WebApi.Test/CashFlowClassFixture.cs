using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WebApi.Test;


//CLASSE QUE TRAZ REFATORAÇÕES
//CRIA O CLIENTE HTTP
//DEFINE A LINGUAGEM DA REQUISIÇÃO
//REALIZA O MÉTODO POST, GET

//USA UMA CLASSE CUSTOMIZADA CustomWebApplicationFactory
//PARA CUSTOMIZAR SEU SERVIDOR HTTP E TAMBÉM O SERVIDOR DO BANCO DE DADOS
//(JÁ QUE O TESTE DE INTEGRAÇÃO NÃO PODE USAR O BANCO DE DADOS PRÓPRIO DA APLICAÇÃO)
public class CashFlowClassFixture : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public CashFlowClassFixture(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    //object request - TIPO DE VARIÁVEL PODE ASSUMIR QUALQUER VALOR
    //NESSE CASO VAI ASSUMIR DIFERENTES VALORES, A DEPENDER DO TESTE EM QUE ESTIVER SENDO
    //USADA
    protected async Task<HttpResponseMessage> DoPost(
        string requestUri, 
        object request,
        string token = "",
        string culture = "en")//CULTURA PADRÃO - INGLES
    {
        AuthorizeRequest(token);
        ChangeRequestCulture(culture);
        var result = await _httpClient.PostAsJsonAsync(requestUri, request);
        return result;
    }

    protected async Task<HttpResponseMessage> DoGet(
        string requestUri,
        string token,//TOKEN OBRIGATÓRIO PARA CONSULTA
        string culture = "en")
    {
        AuthorizeRequest(token);
        ChangeRequestCulture(culture);
        return await _httpClient.GetAsync(requestUri);

    }

    protected async Task<HttpResponseMessage> DoDelete(
        string requestUri,
        string token,
        string culture = "en")
    {
        AuthorizeRequest(token);
        ChangeRequestCulture(culture);
        return await _httpClient.DeleteAsync(requestUri);
    }

    protected async Task<HttpResponseMessage> DoPut(
        string requestUri,
        object request,
        string token,
        string culture = "en")
    {
        AuthorizeRequest(token);
        ChangeRequestCulture(culture);
        return await _httpClient.PutAsJsonAsync(requestUri, request);
    }

    //FUNÇÕES AUXILIARES
    private void AuthorizeRequest(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return;
        //AUTENTICA A REQUISIÇÃO CASO token NÃO SEJA VAZIO OU ESPAÇO EM BRANCO
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
    }

    private void ChangeRequestCulture(string culture)
    {
        //PRECAUÇÃO - GARANTIR QUE HÁ SOMENTE UMA CULTURA NA REQUISIÇÃO, POR CHAMADA DE MÉTODO
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(
            new StringWithQualityHeaderValue(culture));
    }
}
