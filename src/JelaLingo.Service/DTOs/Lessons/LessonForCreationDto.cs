using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Lessons;

public class LessonForCreationDto
{
    [Required(ErrorMessage = "Topic ID is required")]
    public long TopicId { get; set; }

    [Required(ErrorMessage = "Content text is required")]
    public string ContentText { get; set; }
    public string? VideoPath { get; set; }
    public IFormFile VideoFile { get; set; }
}
