using CashFlow.Communication.Requests;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using System.Net.Http.Json;
using System.Globalization;
using WebApi.Test.InlineData;
using CommonTestUtilities.Requests;
using System.Net.Http.Headers;
using CashFlow.Exception;

namespace WebApi.Test.Login.DoLogin;
public class DoLoginTest : IClassFixture<CustomWebApplicationFactory>
{
    private const string METHOD = "api/Login";
    private readonly HttpClient _httpClient;
    private readonly string _email;
    private readonly string _name;
    private readonly string _passwordReal;

    public DoLoginTest(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
        _email = webApplicationFactory.GetEmail();
        _name = webApplicationFactory.GetName();
        _passwordReal = webApplicationFactory.GetPassword();
    }

    [Fact]
    public async Task Sucess()
    {
        var request = new RequestLoginJson
        {
            Email = _email,
            Password = _passwordReal
        };

        var response = await _httpClient.PostAsJsonAsync(METHOD, request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseBody = await response.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseBody);
        responseJson.RootElement.GetProperty("name").GetString().Should().Be(_name);
        responseJson.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }


    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task Error_LoginInvalid(string cultureInfo)
    {
        var request = RequestLoginJsonBuilder.Build();//REQUEST DE UM USUÁRIO QUALQUER QUE
                                                      //NÃO VAI SER O JÁ CADASTRADO NA BD
        _httpClient.DefaultRequestHeaders.AcceptLanguage
                                         .Add(new StringWithQualityHeaderValue(cultureInfo));
        
        var response = await _httpClient.PostAsJsonAsync(METHOD, request);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        var responseBody = await response.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseBody);
        var errors = responseJson.RootElement.GetProperty("errorMessages").EnumerateArray();
        var error = errors.FirstOrDefault().GetString();
        var expectedMessage = ResourceErrorMessages.ResourceManager
                                                   .GetString("EMAIL_OR_PASSWORD_INVALID", 
                                                              new CultureInfo(cultureInfo));
        errors.Should().HaveCount(1);
        error.Should().Be(expectedMessage);


    
    }


}
