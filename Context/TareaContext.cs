using Microsoft.EntityFrameworkCore;
using Proyecto.Modelos;

namespace Proyecto.Context;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias {get;set;}       
    public DbSet<Tarea> Tareas {get;set;}

    public TareaContext (DbContextOptions<TareaContext> opcion) : base (opcion) {}
}
