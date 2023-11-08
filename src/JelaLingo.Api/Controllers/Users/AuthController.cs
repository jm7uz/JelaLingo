using JelaLingo.Service.DTOs.Logins;
using JelaLingo.Service.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Users;

public class AuthController : BaseController
{
    private readonly IAuthService authService;
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(LoginDto dto)
    {
        return Ok(await this.authService.AuthenticateAsync(dto.Email, dto.Password));
    }
}
