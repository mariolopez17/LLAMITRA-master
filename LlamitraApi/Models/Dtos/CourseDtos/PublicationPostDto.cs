using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class PublicationPostDto
    {
        public int IdType { get; set; }
        public int IdUser { get; set; }
        public string Professor { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
