namespace LlamitraApi.Models.Dtos.CourseDtos
{
    public class VideoGetDto
    {
        public string FileName { get; set; }
        public string TitleVideo { get; set; }
        public string DescriptionVideo { get; set; }
        public byte[] FileContent { get; set; }
    }
}
