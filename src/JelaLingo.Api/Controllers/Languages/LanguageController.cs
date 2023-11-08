using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Languages;
using JelaLingo.Service.Interfaces.Languages;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Languages
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LanguageForCreationDto dto)
        => Ok(await _languageService.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _languageService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _languageService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] LanguageForUpdateDto dto)
            => Ok(await _languageService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _languageService.RemoveAsync(id));
    }
}
