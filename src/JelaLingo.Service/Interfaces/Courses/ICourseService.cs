using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Courses;

namespace JelaLingo.Service.Interfaces.Courses
{
    public interface ICourseService
    {
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<CourseForResultDto>> GetAllAsync();
        Task<CourseForResultDto> RetrieveByIdAsync(long id);
        Task<CourseForResultDto> AddAsync(CourseForCreationDto dto);
        Task<CourseForResultDto> ModifyAsync(long id, CourseForUpdateDto dto);
        Task<IEnumerable<CourseForResultDto>> RetrieveAllAsync(PaginationParams @params);
    }
}
