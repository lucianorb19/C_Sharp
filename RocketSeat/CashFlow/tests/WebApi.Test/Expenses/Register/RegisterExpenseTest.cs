using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Expenses.Register;
public class RegisterExpenseTest : IClassFixture<CustomWebApplicationFactory>
{

    private const string METHOD = "api/Expenses";
    private readonly HttpClient _httpClient;
    private readonly string _token;

    public RegisterExpenseTest(CustomWebApplicationFactory webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
        _token = webApplicationFactory.GetToken();
    }


    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterExpenseJsonBuilder.Build();
        //INCLUINDO TOKEN DE AUTENTICAÇÃO NOS HEADERS DA REQUEST
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                                                                         _token);

        var result = await _httpClient.PostAsJsonAsync(METHOD, request);

        result.StatusCode.Should().Be(HttpStatusCode.Created);
        var body = await result.Content.ReadAsStreamAsync();
        var bodyJson = await JsonDocument.ParseAsync(body);
        bodyJson.RootElement.GetProperty("title").GetString().Should().Be(request.Title);
    }


    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task Error_TitleEmpty(string cultureInfo)
    {
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                                                                                         _token);
        _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(cultureInfo));

        var result = await _httpClient.PostAsJsonAsync(METHOD, request);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var body = await result.Content.ReadAsStreamAsync();
        var bodyJson = await JsonDocument.ParseAsync(body);
        var errors = bodyJson.RootElement.GetProperty("errorMessages").EnumerateArray();
        var error = errors.FirstOrDefault().GetString();
        var expectedMessage = ResourceErrorMessages.ResourceManager
                                                   .GetString("TITLE_REQUIRED", 
                            new System.Globalization.CultureInfo(cultureInfo));

        errors.Should().HaveCount(1);
        error.Should().Be(expectedMessage);
    }

}
