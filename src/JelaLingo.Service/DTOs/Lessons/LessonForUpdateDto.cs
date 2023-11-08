using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Lessons;

public class LessonForUpdateDto
{

    [Required(ErrorMessage = "Content text is required")]
    public string ContentText { get; set; }
}
