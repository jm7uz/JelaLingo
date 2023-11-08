using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class Lesson : Auditable
{
    public long TopicId { get; set; }
    public string ContentText { get; set; }
    public string VideoPath { get; set; }
    public Topic Topic { get; set; }

}
