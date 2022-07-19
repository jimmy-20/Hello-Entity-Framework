namespace Proyecto.Modelos
{
    public class Tarea
    {
        public Guid IdTarea {get;}
        public Guid IdCategoria {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public Prioridad Prioridad {get;set;}
        public DateTime FechaCreacion {get;set;}
        public virtual Categoria Categoria {get;set;}
    }

    public enum Prioridad{
        Baja,Media,Alta
    }
}