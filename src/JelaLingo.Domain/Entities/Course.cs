
using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class Course : Auditable
{
    public long LanguageId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Language Language { get; set; }
    public ICollection<Topic> Topics { get; set; }
}
