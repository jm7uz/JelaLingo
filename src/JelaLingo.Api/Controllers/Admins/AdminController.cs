using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Admins;
using JelaLingo.Service.DTOs.Users;
using JelaLingo.Service.Interfaces.Admins;
using JelaLingo.Service.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Admins;

public class UsersController : BaseController
{
    private readonly IAdminService _adminService;
    private readonly IConfiguration _configuration;
    public UsersController(IAdminService adminService, IConfiguration configuration)
    {
        _adminService = adminService;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AdminForCreationDto dto)
        => Ok(await _adminService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _adminService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _adminService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] AdminForUpdateDto dto)
        => Ok(await _adminService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _adminService.RemoveAsync(id));

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(await _adminService.RetrieveByEmailAsync(email));
}
