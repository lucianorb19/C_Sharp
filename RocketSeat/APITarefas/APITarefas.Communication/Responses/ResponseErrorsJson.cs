namespace APITarefas.Communication.Responses;
public class ResponseErrorsJson : ResponseBase
{
    public List<string> Errors { get; set; } = [];
}
