namespace LlamitraApi.Models
{
    public class PublicationType
    {
        public int IdType {  get; set; }
        public string Name { get; set; }
        public virtual ICollection<Publication> Publications { get; set; } = [];
    }
}