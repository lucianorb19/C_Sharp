using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Formats.Asn1;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Test.InlineData;


//TESTE DE INTEGRAÇÃO - REGISTRO DE USUÁRIO

//: IClassFixture<CustomWebApplicationFactory> DEFINE ESSA CLASSE COMO UMA CLASSE DE TESTE
//DE INTEGRAÇÃO. ELA USA UMA CLASSE CUSTOMIZADA CustomWebApplicationFactory
//PARA CUSTOMIZAR SEU SERVIDOR HTTP E TAMBÉM O SERVIDOR DO BANCO DE DADOS
//(JÁ QUE O TESTE DE INTEGRAÇÃO NÃO PODE USAR O BANCO DE DADOS PRÓPRIO DA APLICAÇÃO)
namespace WebApi.Test.Users.Register;
public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
{
    private const string METHOD = "api/User";
    private readonly HttpClient _httpClient;

    public RegisterUserTest(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        

        var result = await _httpClient.PostAsJsonAsync(METHOD,request);
        
        
        //API DEVE PRODUZIR O CÓDIGO CREATED AO REGISTRAR UM USUÁRIO COM SUCESSO
        result.StatusCode.Should().Be(HttpStatusCode.Created);
        //API DEVE DEVOLVER UM OBJETO COM PROPRIEDADE STRING name CUJO
        //VALOR SEJA IGUAL AO PASSADO NA REQUEST
        var body = await result.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(body);
        responseJson.RootElement.GetProperty("name").GetString().Should().Be(request.Name);
        //DEVOLVER TAMBÉM PROPRIEDADE token NÃO NULA OU NÃO VAZIA
        responseJson.RootElement.GetProperty("token").GetString().Should().NotBeNullOrEmpty();
    }


    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]//USA OS RETURNS DA CLASSE CultureInlineDataTest COMO PARÂMETROS DE TESTE
    public async Task Error_EmptyNameWithDifferentLanguages(string cultureInfo)
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        //ACEITAR RESPOSTA EM pt-BR DA API
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(cultureInfo));

        var result = await _httpClient.PostAsJsonAsync(METHOD, request);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var body = await result.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(body);
        var errorsList = responseJson.RootElement.GetProperty("errorMessages").EnumerateArray();
        errorsList.Should().HaveCount(1);
        var error = errorsList.FirstOrDefault().GetString()!;
        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(cultureInfo))!;
        error.Should().Be(expectedMessage);
      
    }


}
