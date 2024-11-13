using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class PublicacionGetDto
    {
        public int IdPublication { get; set; }

        
        public int IdType { get; set; }

        
        public int IdUser { get; set; }

        
        public string Professor { get; set; }

        
        public decimal Price { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public byte[] FileContent { get; set; }

        public List<VideoDto> Videos { get; set; }

    }


   
}
