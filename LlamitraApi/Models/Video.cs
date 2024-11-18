using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LlamitraApi.Models
{
    [Table("Video")]
    public class Video
    {
        [Key]
        public int IdVideo { get; set; }

        public int PublicationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public List<string> FilePath { get; set; } = new List<string>();
        
        [ForeignKey("PublicationId")]
        public Publication Publication { get; set; }
    }

}
