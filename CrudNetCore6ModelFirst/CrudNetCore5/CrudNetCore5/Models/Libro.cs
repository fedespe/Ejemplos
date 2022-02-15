using System.ComponentModel.DataAnnotations;

namespace CrudNetCore5.Models
{
    public class Libro
    {
        [Key]//Indica que es llave primaria de la tabla Libro en la base de datos. Solo poniendo Id y [key] es autoincremental.
        public int Id { get; set; }

        [Required(ErrorMessage ="El título es obligatorio.")]
        [StringLength(50,ErrorMessage ="El título debe contener entre 2 a 50 caracteres.",MinimumLength =2)]
        [Display(Name ="Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, ErrorMessage = "La descripción debe contener entre 2 a 50 caracteres.", MinimumLength = 2)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public int Precio { get; set; }
    }
}
