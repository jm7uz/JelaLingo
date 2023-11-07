using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class UserLanguage : Auditable
{
    public long UserId { get; set; }
    public long LanguageId { get; set; }
    public User User { get; set; }
    public Language Language { get; set; }
}
