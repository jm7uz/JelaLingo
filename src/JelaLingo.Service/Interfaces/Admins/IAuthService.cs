using JelaLingo.Service.DTOs.Logins;

namespace JelaLingo.Service.Interfaces.Admins;

public interface IAuthService
{
    Task<LoginResultDto> AuthenticateAsync(string email, string password);
}
