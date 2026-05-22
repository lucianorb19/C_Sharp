using APITarefas.Communication.Enums;

namespace APITarefas.Communication.Responses;
public class ResponseTaskJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public Status Status { get; set; }
    public string DueDate { get; set; } = string.Empty;
}
