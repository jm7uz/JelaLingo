using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Lessons;
using JelaLingo.Service.Interfaces.Lessons;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Lessons
{
    public class LessonController : BaseController
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] LessonForCreationDto dto)
        {
            var videoPath = await _lessonService.SaveVideoFileAsync(dto.VideoFile);
            dto.VideoPath = videoPath;

            return Ok(await _lessonService.AddAsync(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _lessonService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _lessonService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] LessonForUpdateDto dto)
            => Ok(await _lessonService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _lessonService.RemoveAsync(id));
    }
}
