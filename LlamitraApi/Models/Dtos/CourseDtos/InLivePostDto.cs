using System.ComponentModel.DataAnnotations;

namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class InLivePostDto
    {
        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre del profesor no puede superar los 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\@]+$", ErrorMessage = "El Nombre del profesor solo debe contener letras")]
        public string Professor { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio, aunque sea 0.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        [RegularExpression(@"^[0-9\s]+$", ErrorMessage = "El precio solo debe contener números.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(50, ErrorMessage = "El título no puede superar los 50 caracteres.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [StringLength(400, ErrorMessage = "La descripción no puede superar los 400 caracteres.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La URL es obligatoria.")]
        [Url(ErrorMessage = "La URL debe ser válida.")]
        [Youtube]
        public string Url { get; set; }
    }
}
