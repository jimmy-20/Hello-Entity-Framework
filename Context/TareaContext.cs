using Microsoft.EntityFrameworkCore;
using Proyecto.Modelos;

namespace Proyecto.Context;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias {get;set;}       
    public DbSet<Tarea> Tareas {get;set;}

    public TareaContext (DbContextOptions<TareaContext> opcion) : base (opcion) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Creando Tabla Categoria
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");

            //Llave Primaria
            categoria.HasKey(c => c.CategoriaId);

            //Propiedades
            categoria.Property(c => c.Nombre).HasMaxLength(150).IsRequired();
            categoria.Property(c => c.Descripcion);
        });

        //Creando Tabla Tarea
        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");

            //Llave Primaria
            tarea.HasKey(t => t.TareaId);
            
            //Llave Foranea; De  la propiedad Categoria de Tarea, Tareas de Categoria tiene una llave
            //foranea por cada CategoriaId de Tarea
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);

            //Propiedades
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion);
            tarea.Property(t => t.Prioridad);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);
            
        });

    }
}
