namespace PrimeiraAPI.Communication.Request;
public class RequestBookJson
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

}
