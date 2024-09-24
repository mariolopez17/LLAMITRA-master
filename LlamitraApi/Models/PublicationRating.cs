namespace LlamitraApi.Models
{
    public class PublicationRating
    {
        public int Id { get; set; }
        public int IdPublication { get; set; } 
        public int Rating { get; set; }
        public int IdUser { get; set; }

        public virtual Publication IdPublicationNavigation { get; set; }
    }
}
