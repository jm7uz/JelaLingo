using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Topics;
using JelaLingo.Service.Interfaces.Topics;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Topics
{
    public class TopicController : BaseController
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TopicForCreationDto dto)
        => Ok(await _topicService.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _topicService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _topicService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] TopicForUpdateDto dto)
            => Ok(await _topicService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _topicService.RemoveAsync(id));
    }
}
