using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Users.ChangePassword;
public class ChangePasswordTest : CashFlowClassFixture
{
    private const string METHOD = "api/User/change-password";
    private readonly string _token;
    private readonly string _password;
    private readonly string _email;

    public ChangePasswordTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.User_Team_Member.GetToken();
        _password = webApplicationFactory.User_Team_Member.GetPassword();
        _email = webApplicationFactory.User_Team_Member.GetEmail();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestChangePasswordJsonBuilder.Build();
        request.Password = _password;

        var response = await DoPut(METHOD, request: request, token: _token);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        //VERIFICAÇÃO - EFETUAR LOGIN COM SENHA ANTES DA ATUALIZAÇÃO, AINDA FUNCIONA?
        //NÃO DEVERIA
        var loginRequest = new RequestLoginJson
        {
            Email = _email,
            Password = _password
        };
        response = await DoPost(requestUri: "api/Login", request: loginRequest);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        //EFETUAR LOGIN COM NOVA SENHA, DEVERIA FUNCIONAR
        loginRequest.Password = request.NewPassword;
        response = await DoPost(requestUri: "api/Login", request: loginRequest);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }


    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task ErrorPasswordDifferentCurrentPassword(string culture)
    {
        var request = RequestChangePasswordJsonBuilder.Build();
        
        var response = await DoPut(METHOD, request: request, token: _token, culture: culture);

        //SENHA GERADA PELO FAKER USADO NA REQUEST NÃO VAI COINCIDAR COM 
        //A SENHA GERADA PELO CUSTOMWEBAPPLICATION PARA ESSE USUÁRIO 
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var responseBody = await response.Content.ReadAsStreamAsync();
        var responseJson = await JsonDocument.ParseAsync(responseBody);
        var errors = responseJson.RootElement.GetProperty("errorMessages").EnumerateArray();
        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("PASSWORD_DIFFERENT_CURRENT_PASSWORD", new CultureInfo(culture));
        errors.Should().HaveCount(1).And
                                    .Contain(erro => erro.GetString()!.Equals(expectedMessage));

    }




}
