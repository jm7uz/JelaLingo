using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}