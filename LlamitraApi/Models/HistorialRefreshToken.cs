namespace LlamitraApi.Models
{
    public class HistorialRefreshToken
    {
        public int IdHistorialToken { get; set; }
        public int? IdUser { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiratedAt { get; set; }
        public bool? IsActive { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
