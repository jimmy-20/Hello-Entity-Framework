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
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){
            CategoriaId =  Guid.Parse("2b91a62d-8567-49ac-b881-a3e3c503d2c0"),
            Nombre = "Actividades Pendientes",
            Descripcion = "Tareas que estan en espera",
            Peso =  5
        });

        categoriasInit.Add(new Categoria(){
            CategoriaId =  Guid.Parse("2b91a62d-8567-49ac-b881-a3e3c503d2c1"),
            Nombre = "Actividades en Curso",
            Descripcion = "Tareas que se estan realizando en el trascurso del tiempo",
            Peso =  8
        });

        categoriasInit.Add(new Categoria(){
            CategoriaId =  Guid.Parse("2b91a62d-8567-49ac-b881-a3e3c503d2c2"),
            Nombre = "Actividades Finalizadas",
            Descripcion = "Tareas cumplidas o tareas terminadas a tiempo",
            Peso =  22
        });

        //Creando Tabla Categoria
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");

            //Llave Primaria
            categoria.HasKey(c => c.CategoriaId);

            //Propiedades
            categoria.Property(c => c.Nombre).HasMaxLength(150).IsRequired();
            categoria.Property(c => c.Descripcion).IsRequired(false);
            categoria.Property(c => c.Peso);

            //Asignando datos iniciales
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        
        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("f3bfb392-1eae-4ae4-a27b-83ab9f2777b7"),
            CategoriaId = Guid.Parse("2b91a62d-8567-49ac-b881-a3e3c503d2c1"),
            Titulo = "Estudiando el curso de Fundamentos Entity Framework",
            Descripcion = "Se investiga el uso de Entity Framework por Platzi",
            Prioridad = Prioridad.Alta,
            FechaCreacion = DateTime.Now,
            FechaFinalizacion = DateTime.Now,
        });

        tareasInit.Add(new Tarea(){
            TareaId = Guid.Parse("f3bfb392-1eae-4ae4-a27b-83ab9f2777b8"),
            CategoriaId = Guid.Parse("2b91a62d-8567-49ac-b881-a3e3c503d2c2"),
            Titulo = "I Semestre 2022",
            Prioridad = Prioridad.Alta,
            FechaCreacion = DateTime.Parse("2022-03-03"),
            FechaFinalizacion  = DateTime.Parse("2022-07-03")
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
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Property(t => t.Prioridad);
            tarea.Property(t => t.FechaCreacion).IsRequired();
            tarea.Property(t => t.FechaFinalizacion).IsRequired();
            tarea.Ignore(t => t.Resumen);
            
            //Asignando datos iniciales
            tarea.HasData(tareasInit);
        });

    }
}
