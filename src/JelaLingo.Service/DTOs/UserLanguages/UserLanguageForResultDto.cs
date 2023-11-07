namespace JelaLingo.Service.DTOs.UserLanguages;

public class UserLanguageForResultDto
{
    public long UserId { get; set; }
    public long LanguageId { get; set; }
    public string UserName { get; set; } 
    public string LanguageName { get; set; }
}
