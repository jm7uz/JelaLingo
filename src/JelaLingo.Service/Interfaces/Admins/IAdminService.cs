using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Admins;

namespace JelaLingo.Service.Interfaces.Admins;

public interface IAdminService
{
    Task<bool> RemoveAsync(long id);
    Task<AdminForResultDto> RetrieveByIdAsync(long id);
    Task<AdminForResultDto> AddAsync(AdminForCreationDto dto);
    Task<AdminForResultDto> RetrieveByEmailAsync(string email);
    Task<AdminForResultDto> ModifyAsync(long id, AdminForUpdateDto dto);
    Task<IEnumerable<AdminForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
