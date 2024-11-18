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
        public string DescriptionProgram { get; set; }
        public string Duration { get; set; }
        public string DurationWeek { get; set; }
        public string Category { get; set; }
        public string KnowledgeLevel { get; set; }
        public bool Favorite { get; set; }
        public bool Comprado { get; set; }

        [JsonIgnore]
        public byte[] FileContent { get; set; }

        public List<VideoDto> VideoDetails { get; set; }

    }


   
}
