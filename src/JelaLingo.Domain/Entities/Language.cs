using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class Language : Auditable
{
    public string Name { get; set; }
    public string Code { get; set; }

    public ICollection<Course> Courses { get; set; }
    public ICollection<UserLanguage> UserLanguages { get; set; }
}
