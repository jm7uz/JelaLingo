using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class Topic : Auditable
{
    public long CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Course Course { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}

