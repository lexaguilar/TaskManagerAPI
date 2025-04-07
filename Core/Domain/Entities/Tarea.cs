namespace TaskManagerAPI.Core.Domain.Entities;

public class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaVencimiento { get; set; }
    public bool Completada { get; set; } = false;
    
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
}