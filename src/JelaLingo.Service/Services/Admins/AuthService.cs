using JelaLingo.Shared.Helpers;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.DTOs.Logins;
using JelaLingo.Service.Interfaces.Admins;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using JelaLingo.Service.DTOs.Users;
using JelaLingo.Service.DTOs.Admins;
using JelaLingo.Domain.Entities;

namespace JelaLingo.Service.Services.Admins;

public class AuthService : IAuthService
{
    private readonly IAdminService _adminService;
    private readonly IConfiguration _configuration;

    public AuthService(IAdminService adminService, IConfiguration configuration)
    {
        _adminService = adminService;
        _configuration = configuration;
    }
    public async Task<LoginResultDto> AuthenticateAsync(string email, string password)
    {
        var admin = await _adminService.RetrieveByEmailAsync(email);
        if (admin == null || !PasswordHelper.Verify(password, admin.Password))
            throw new JelalingoException(400, "Email or password is incorrect");


        return new LoginResultDto
        {
            Token = GenerateToken(admin)
        };
    }

    private string GenerateToken(AdminForResultDto admin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", admin.Id.ToString()),
                 new Claim(ClaimTypes.Name, admin.FirstName)
            }),
            Audience = _configuration["JWT:Audience"],
            Issuer = _configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
