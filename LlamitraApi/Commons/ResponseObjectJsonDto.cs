using System.Text.Json.Serialization;

namespace LlamitraApi.Commons
{
    public class ResponseObjectJsonDto
    {
        [JsonPropertyName("response")]
        public object? Response { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
