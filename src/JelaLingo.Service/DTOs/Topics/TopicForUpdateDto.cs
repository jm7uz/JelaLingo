using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Topics;

public class TopicForUpdateDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title must be between 5 and 100 characters", MinimumLength = 5)]
    public string Title { get; set; }

    public string Description { get; set; }
    public long CourseId { get; set; }
}
