using JelaLingo.Service.DTOs.Logins;

namespace JelaLingo.Service.Interfaces.Users;

public interface IAuthService
{
    Task<LoginResultDto> AuthenticateAsync(string email, string password);
}
