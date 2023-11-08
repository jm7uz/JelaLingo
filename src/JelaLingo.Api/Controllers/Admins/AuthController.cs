using JelaLingo.Service.DTOs.Logins;
using JelaLingo.Service.Interfaces.Admins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Admins;

public class AdminAuthController : BaseController
{
    private readonly IAdminAuthService authService;
    public AdminAuthController(IAdminAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(LoginDto dto)
    {
        return Ok(await this.authService.AuthenticateAsync(dto.Email, dto.Password));
    }
}
