namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class VideoGetDto
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] FileContent { get; set; }
    }

}
