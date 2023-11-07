using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Courses;

public class CourseForCreationDto
{
    [Required(ErrorMessage = "Language ID is required")]
    public long LanguageId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title must be between 2 and 100 characters", MinimumLength = 2)]
    public string Title { get; set; }

    [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
    public string Description { get; set; }
}
