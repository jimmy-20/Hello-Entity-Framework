using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Modelos
{
    public class Tarea
    {
        [Key]
        public Guid IdTarea {get;}

        [ForeignKey("IdCategoria")]
        public Guid IdCategoria {get;set;}

        [Required]
        [MaxLength(200)]
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public Prioridad Prioridad {get;set;}
        public DateTime FechaCreacion {get;set;}
        public virtual Categoria Categoria {get;set;}

        [NotMapped]
        public string Resumen {get;set;}
    }

    public enum Prioridad{
        Baja,Media,Alta
    }
}