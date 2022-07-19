using System.ComponentModel.DataAnnotations;

namespace Proyecto.Modelos
{
    public class Categoria
    {
        [Key]
        public Guid IdCategoria {get;set;}

        [Required]
        [MaxLength(150)]
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public virtual ICollection<Tarea> Tareas {get;set;}
    }
}