using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.UserLanguages;

public class UserLanguageForCreationDto
{
    [Required(ErrorMessage = "User ID is required")]
    public long UserId { get; set; }

    [Required(ErrorMessage = "Language ID is required")]
    public long LanguageId { get; set; }
}
