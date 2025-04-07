// Core/Infrastructure/Repositories/UnsafeTareaRepository.cs
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Core.Domain.Entities;
using TaskManagerAPI.Core.Infrastructure.Data;

public class UnsafeTareaRepository
{
    private readonly AppDbContext _context;
    
    public UnsafeTareaRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Tarea> GetTareasByTitle(string title)
    {
        // SonarQube: S3649 - SQL injection
        var sql = $"SELECT * FROM Tareas WHERE Titulo = '{title}'";
        return _context.Tareas.FromSqlRaw(sql).ToList();
    }
}