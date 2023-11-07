using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Lessons;

public class LessonForCreationDto
{
    [Required(ErrorMessage = "Topic ID is required")]
    public long TopicId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title must be between 5 and 200 characters", MinimumLength = 5)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content text is required")]
    public string ContentText { get; set; }

    [Required(ErrorMessage = "Video Path is required")]
    public string VideoPath { get; set; }


}
