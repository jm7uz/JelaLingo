using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.UserLanguages;

namespace JelaLingo.Service.Interfaces.UserLanguages;

public interface IUserLanguageService
{
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<UserLanguageForResultDto>> GetAllAsync();
    Task<UserLanguageForResultDto> RetrieveByIdAsync(long id);
    Task<UserLanguageForResultDto> AddAsync(UserLanguageForCreationDto dto);
}
