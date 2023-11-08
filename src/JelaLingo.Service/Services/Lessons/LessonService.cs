using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Lessons;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Extensions;
using JelaLingo.Service.Interfaces.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.Lessons;

public class LessonService : ILessonService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Lesson> _lessonRepository;

    public LessonService(IMapper mapper, IRepository<Lesson> lessonRepository)
    {
        _mapper = mapper;
        _lessonRepository = lessonRepository;
    }

    public async Task<LessonForResultDto> AddAsync(LessonForCreationDto dto)
    {
        var lessons = await _lessonRepository.SelectAll()
            .Where(l => l.TopicId == dto.TopicId)
            .FirstOrDefaultAsync();
        if (lessons is not null)
            throw new JelalingoException(409, "Course is alredy exists");

        var lesson = _mapper.Map<Lesson>(dto);
        lesson.CreatedAt = DateTime.UtcNow;

        var createdLesson = await _lessonRepository.InsertAsync(lesson);
        return _mapper.Map<LessonForResultDto>(createdLesson);
    }

    public async Task<IEnumerable<LessonForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var query = _lessonRepository.SelectAll()
                .AsNoTracking();

        var lessons = await query
                .Skip((@params.PageIndex - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToListAsync();

        return _mapper.Map<IEnumerable<LessonForResultDto>>(lessons);
    }

    public async Task<LessonForResultDto> RetrieveByIdAsync(long id)
    {
        var lesson = await _lessonRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
        if (lesson == null)
            throw new JelalingoException(404, "Lesson not found");

        return _mapper.Map<LessonForResultDto>(lesson);
    }

    public async Task<LessonForResultDto> ModifyAsync(long id, LessonForUpdateDto dto)
    {
        var lesson = await _lessonRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
        if (lesson == null)
            throw new JelalingoException(404, "Lesson not found");

        lesson.UpdatedAt = DateTime.UtcNow;
        var mappedLesson = _mapper.Map(dto, lesson);

        await _lessonRepository.UpdateAsync(mappedLesson);

        return _mapper.Map<LessonForResultDto>(mappedLesson);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var lesson = await _lessonRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
        if (lesson == null)
            throw new JelalingoException(404, "Lesson not found");

        await _lessonRepository.DeleteAsync(id);

        return true;
    }
    public async Task<IEnumerable<LessonForResultDto>> GetAllAsync()
    {
        var lessons = await _lessonRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<LessonForResultDto>>(lessons);
    }

    public async Task<string> SaveVideoFileAsync(IFormFile videoFile)
    {
        var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "videos");

        if (!Directory.Exists(uploadsFolderPath))
        {
            Directory.CreateDirectory(uploadsFolderPath);
        }
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(videoFile.FileName);
        var filePath = Path.Combine(uploadsFolderPath, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await videoFile.CopyToAsync(stream);
        }

        return Path.Combine("videos", fileName);
    }
}
