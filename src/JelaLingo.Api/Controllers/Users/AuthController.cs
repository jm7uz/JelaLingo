using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using JelaLingo.Service.DTOs.Logins;
using JelaLingo.Service.Interfaces.Users;

namespace JelaLingo.Api.Controllers.Users;

public class UserAuthController : BaseController
{
    private readonly IUserAuthService _authService;
    public UserAuthController(IUserAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(LoginDto dto)
    {
        return Ok(await _authService.AuthenticateAsync(dto.Email, dto.Password));
    }
}
