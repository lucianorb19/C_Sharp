using FluentAssertions;
using System.Net;
using System.Text.Json;

namespace WebApi.Test.Users.Profile;
public class GetUserProfileTest : CashFlowClassFixture
{

    private const string METHOD = "api/User";
    private readonly string _token;
    private readonly string _userName;
    private readonly string _userEmail;

    public GetUserProfileTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.User_Team_Member.GetToken();
        _userName = webApplicationFactory.User_Team_Member.GetName();
        _userEmail = webApplicationFactory.User_Team_Member.GetEmail();
    }

    [Fact]
    public async Task Success()
    {
        var result = await DoGet(METHOD, _token);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await result.Content.ReadAsStreamAsync();
        var bodyJson = await JsonDocument.ParseAsync(body);
        bodyJson.RootElement.GetProperty("name").GetString().Should().Be(_userName);
        bodyJson.RootElement.GetProperty("email").GetString().Should().Be(_userEmail);
    }



}
