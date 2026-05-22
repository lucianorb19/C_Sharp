using APITarefas.Communication.Enums;
using System.ComponentModel.DataAnnotations;

namespace APITarefas.API.Entities;

public class Task
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required Priority Priority { get; set; }
    public required Status Status { get; set; }
    public required DateTime DueDate { get; set; }

}
