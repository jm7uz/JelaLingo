using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Lessons;
using Microsoft.AspNetCore.Http;

namespace JelaLingo.Service.Interfaces.Lessons;
public interface ILessonService
{
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<LessonForResultDto>> GetAllAsync();
    Task<LessonForResultDto> RetrieveByIdAsync(long id);
    Task<string> SaveVideoFileAsync(IFormFile videoFile);
    Task<LessonForResultDto> AddAsync(LessonForCreationDto dto);
    Task<LessonForResultDto> ModifyAsync(long id, LessonForUpdateDto dto);
    Task<IEnumerable<LessonForResultDto>> RetrieveAllAsync(PaginationParams @params);

}
