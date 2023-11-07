using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Languages;

public class LanguageForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30, ErrorMessage = "Name must be between 2 and 30 characters", MinimumLength = 2)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Code is required")]
    [StringLength(6, ErrorMessage = "Code must be between 2 and 6 characters", MinimumLength = 2)]
    public string Code { get; set; }
}
