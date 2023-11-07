namespace JelaLingo.Service.DTOs.Lessons;

public class LessonForResultDto
{
    public long Id { get; set; }
    public long TopicId { get; set; }
    public string Title { get; set; }
    public string ContentText { get; set; }
    public string VideoPath { get; set; }
}
