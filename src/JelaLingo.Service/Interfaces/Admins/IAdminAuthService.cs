using JelaLingo.Service.DTOs.Logins;

namespace JelaLingo.Service.Interfaces.Admins;

public interface IAdminAuthService
{
    Task<LoginResultDto> AuthenticateAsync(string email, string password);
}
