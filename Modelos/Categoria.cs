namespace Proyecto.Modelos
{
    public class Categoria
    {
        public Guid IdCategoria {get;set;}
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public virtual ICollection<Tarea> Tareas {get;set;}
    }
}