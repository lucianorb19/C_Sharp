using APITarefas.Communication.Enums;

namespace APITarefas.Communication.Responses;
public class ResponseShortTaskJson
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public Status Status { get; set; }
    public string DueDate { get; set; } = string.Empty;
}
