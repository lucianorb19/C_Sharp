using APITarefas.Communication.Enums;

namespace APITarefas.Communication.Responses;
public class ResponseRegisterTaskJson : ResponseBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public Status Status { get; set; }
    public string DueDate { get; set; } = string.Empty;
}
