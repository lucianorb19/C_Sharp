using APITarefas.Communication.Enums;

namespace APITarefas.Communication.Requests;
public class RequestTaskJson
{
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required Priority Priority { get; set; }
    public required Status Status { get; set; }
    public required DateTime DueDate { get; set; }
}
