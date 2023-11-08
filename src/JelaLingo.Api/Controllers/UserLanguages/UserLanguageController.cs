using JelaLingo.Service.DTOs.UserLanguages;
using JelaLingo.Service.Interfaces.UserLanguages;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.UserLanguages
{
    public class UserLanguageController : BaseController
    {
        private readonly IUserLanguageService _userLanguageService;

        public UserLanguageController(IUserLanguageService userLanguageService)
        {
            _userLanguageService = userLanguageService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserLanguageForCreationDto dto)
        => Ok(await _userLanguageService.AddAsync(dto));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _userLanguageService.RetrieveByIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _userLanguageService.RemoveAsync(id));

    }
}
