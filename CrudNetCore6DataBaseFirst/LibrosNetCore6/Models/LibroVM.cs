using ET;
using System.ComponentModel.DataAnnotations;

namespace LibrosNetCore6.Models
{
    public class LibroVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Clienet: El título es obligatorio.")]
        [StringLength(50, ErrorMessage = "Clienet: El título debe contener entre 2 a 50 caracteres.", MinimumLength = 2)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Clienet: La descripción es obligatoria.")]
        [StringLength(300, ErrorMessage = "Clienet: La descripción debe contener entre 2 a 300 caracteres.", MinimumLength = 2)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Clienet: La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "Clienet: Clienet: El autor es obligatorio.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Clienet: El precio es obligatorio.")]
        public double Precio { get; set; }
    }
}
