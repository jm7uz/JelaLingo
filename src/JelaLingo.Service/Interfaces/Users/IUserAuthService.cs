using JelaLingo.Service.DTOs.Logins;

namespace JelaLingo.Service.Interfaces.Users;

public interface IUserAuthService
{
    Task<LoginResultDto> AuthenticateAsync(string email, string password);
}
