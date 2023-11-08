using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Topics;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Extensions;
using JelaLingo.Service.Interfaces.Topics;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.Topics;

public class TopicService : ITopicService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Topic> _topicRepository;

    public TopicService(IMapper mapper, IRepository<Topic> topicRepository)
    {
        _mapper = mapper;
        _topicRepository = topicRepository;
    }

    public async Task<TopicForResultDto> AddAsync(TopicForCreationDto dto)
    {
        var topics = await _topicRepository.SelectAll()
            .Where(l => l.Title.ToLower() == dto.Title.ToLower())
            .FirstOrDefaultAsync();
        if (topics is not null)
            throw new JelalingoException(409, "Topic is alredy exists");

        var topic = _mapper.Map<Topic>(dto);
        topic.CreatedAt = DateTime.UtcNow;

        var createdTopic = await _topicRepository.InsertAsync(topic);
        return _mapper.Map<TopicForResultDto>(createdTopic);
    }

    public async Task<IEnumerable<TopicForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var query = _topicRepository.SelectAll()
                .AsNoTracking();

        var pagedTopics = await query
                .Skip((@params.PageIndex - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToListAsync();

        return _mapper.Map<IEnumerable<TopicForResultDto>>(pagedTopics);
    }

    public async Task<TopicForResultDto> RetrieveByIdAsync(long id)
    {
        var topic = await _topicRepository.SelectAll()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        if (topic == null)
            throw new JelalingoException(404, "Topic not found");

        return _mapper.Map<TopicForResultDto>(topic);
    }

    public async Task<TopicForResultDto> ModifyAsync(long id, TopicForUpdateDto dto)
    {
        var topic = await _topicRepository.SelectAll()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();

        if (topic == null)
            throw new JelalingoException(404, "Topic not found");

        topic.UpdatedAt = DateTime.UtcNow;
        var mappedTopic = _mapper.Map(dto, topic);

        await _topicRepository.UpdateAsync(mappedTopic);

        return _mapper.Map<TopicForResultDto>(mappedTopic);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var topic = await _topicRepository.SelectAll()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
        if (topic == null)
            throw new JelalingoException(404, "Topic not found");

        await _topicRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<TopicForResultDto>> GetAllAsync()
    {
        var topics = await _topicRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<TopicForResultDto>>(topics);
    }
}
