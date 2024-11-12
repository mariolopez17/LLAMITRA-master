using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LlamitraApi.Models
{
    [Table("Video")]
    public class Video
    {
        [Key]
        public int IdVideo { get; set; }  

        public int PublicationId { get; set; } 

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede superar los 100 caracteres.")]
        public string Title { get; set; }  

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
        public string Description { get; set; }  

        public string FileName { get; set; }
        public List<string> FilePath { get; set; } = new List<string>();


        [ForeignKey("PublicationId")]
        public virtual Publication Publication { get; set; }
    }
}
