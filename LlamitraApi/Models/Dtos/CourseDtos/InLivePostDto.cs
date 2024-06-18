using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class InLivePostDto
    {
        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre del profesor no puede superar los 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\@]+$", ErrorMessage = "El Nombre del profesor solo debe contener letras")]
        [JsonPropertyName("profesor")]
        public string Professor { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio, aunque sea 0.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        [RegularExpression(@"^\d{1,10}([\,\.]\d{1,2})?$", ErrorMessage = "El precio solo debe contener números y no acepta mas de 2 cifras decimales.")]
        [JsonPropertyName("precio")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(50, ErrorMessage = "El título no puede superar los 50 caracteres.")]
        [JsonPropertyName("título")]
        public string Title { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [StringLength(400, ErrorMessage = "La descripción no puede superar los 400 caracteres.")]
        [JsonPropertyName("descripción")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La URL es obligatoria.")]
        [Url(ErrorMessage = "La URL debe ser válida.")]
        [Youtube]
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
