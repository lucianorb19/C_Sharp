using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Users.Register;

//TESTE DE INTEGRAÇÃO - REGISTRO DE USUÁRIO
//HERDA DE CashFlowClassFixture - CLASSE QUE POSSUI REFATORAÇÕES DO CÓDIGO
public class RegisterUserTest : CashFlowClassFixture
{
    private const string METHOD = "api/User";

    //CONSTRUTOR CHAMA O CONSTRUTOR DA CLASSE BASE
    public RegisterUserTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory){}

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
       

        var result = await DoPost(requestUri: METHOD, request: request);
        
        
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
    public async Task Error_EmptyNameWithDifferentLanguages(string culture)
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
      

        var result = await DoPost(requestUri:METHOD, request:request, culture:culture);


        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var body = await result.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(body);
        var errorsList = responseJson.RootElement.GetProperty("errorMessages").EnumerateArray();
        errorsList.Should().HaveCount(1);
        var error = errorsList.FirstOrDefault().GetString()!;
        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture))!;
        error.Should().Be(expectedMessage);
    }


}
