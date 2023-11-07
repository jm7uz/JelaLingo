using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Topics;

namespace JelaLingo.Service.Interfaces.Topics;

public interface ITopicService
{
    Task<bool> RemoveAsync(long id);
    Task<IEnumerable<TopicForResultDto>> GetAllAsync();
    Task<TopicForResultDto> RetrieveByIdAsync(long id);
    Task<TopicForResultDto> AddAsync(TopicForCreationDto dto);
    Task<TopicForResultDto> ModifyAsync(long id, TopicForUpdateDto dto);
    Task<IEnumerable<TopicForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
