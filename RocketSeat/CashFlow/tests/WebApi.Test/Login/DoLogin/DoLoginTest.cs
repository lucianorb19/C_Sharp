using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Login.DoLogin;
public class DoLoginTest : CashFlowClassFixture
{
    private const string METHOD = "api/Login";
    private readonly string _email;
    private readonly string _name;
    private readonly string _passwordReal;

    public DoLoginTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _email = webApplicationFactory.User_Team_Member.GetEmail();
        _name = webApplicationFactory.User_Team_Member.GetName();
        _passwordReal = webApplicationFactory.User_Team_Member.GetPassword();
    }

    [Fact]
    public async Task Sucess()
    {
        var request = new RequestLoginJson
        {
            Email = _email,
            Password = _passwordReal
        };


        var response = await DoPost(requestUri:METHOD, request:request);


        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseBody = await response.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseBody);
        responseJson.RootElement.GetProperty("name").GetString().Should().Be(_name);
        responseJson.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }


    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task Error_LoginInvalid(string culture)
    {
        var request = RequestLoginJsonBuilder.Build();//REQUEST DE UM USUÁRIO QUALQUER QUE
                                                      //NÃO VAI SER O JÁ CADASTRADO NA BD
        
       
        var response = await DoPost(requestUri:METHOD,request:request, culture:culture);


        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        var responseBody = await response.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseBody);
        var errors = responseJson.RootElement.GetProperty("errorMessages").EnumerateArray();
        var error = errors.FirstOrDefault().GetString();
        var expectedMessage = ResourceErrorMessages.ResourceManager
                                                   .GetString("EMAIL_OR_PASSWORD_INVALID", 
                                                              new CultureInfo(culture));
        errors.Should().HaveCount(1);
        error.Should().Be(expectedMessage);
    }


}
