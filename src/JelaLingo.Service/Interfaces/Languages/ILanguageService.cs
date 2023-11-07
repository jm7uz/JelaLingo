using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Languages;

namespace JelaLingo.Service.Interfaces.Languages;

public interface ILanguageService
{
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<LanguageForResultDto>> GetAllAsync();
    Task<LanguageForResultDto> RetrieveByIdAsync(long id);
    Task<LanguageForResultDto> AddAsync(LanguageForCreationDto dto);
    Task<LanguageForResultDto> ModifyAsync(long id, LanguageForUpdateDto dto);
    Task<IEnumerable<LanguageForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
