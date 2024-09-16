using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class PublicationTypePostDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\@]+$", ErrorMessage = "El Nombre solo debe contener letras.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El Nombre debe tener entre 1 y 20 caracteres como maximo.")]
        
        public string Name { get; set; }
    }
}
