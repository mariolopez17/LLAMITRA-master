using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class PublicationPostDto
    {
        [Required(ErrorMessage = "El ID del tipo de publicación es obligatorio.")]
        [RegularExpression(@"^\d{1,10}([\,\.]\d{1,2})?$", ErrorMessage = "El ID del tipo de publicación solo debe contener números.")]
        public int IdType { get; set; }

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        [RegularExpression(@"^\d{1,10}([\,\.]\d{1,2})?$", ErrorMessage = "El ID del usuario solo debe contener números.")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [StringLength(20, ErrorMessage = "El nombre del profesor no puede superar los 20 caracteres.")]
        [RegularExpression(@"^[a-zA-Z@ ]+$", ErrorMessage = "El nombre del profesor solo debe contener letras.")]
        public string Professor { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio, aunque sea 0.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        [RegularExpression(@"^\d{1,10}([\,\.]\d{1,2})?$", ErrorMessage = "El precio solo debe contener números y no acepta más de 2 cifras decimales.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(50, ErrorMessage = "El título no puede superar los 50 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(400, ErrorMessage = "La descripción no puede superar los 400 caracteres.")]
        public string Description { get; set; }

        [JsonIgnore]
        public List<IFormFile> Videos { get; set; } 

        public List<VideoDto> VideoDetails { get; set; }
    }
}