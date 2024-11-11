using System.ComponentModel.DataAnnotations.Schema;

namespace LlamitraApi.Models
{
    [Table("Publication")]
    public class Publication
    {
        public int IdPublication { get; set; }
        public int IdType { get; set; }
        public int IdUser { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Professor { get; set; }
        public string Title { get; set; }
        public virtual PublicationType IdTypeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<PublicationRating> PublicationRatings { get; set; }
        public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
    }
}