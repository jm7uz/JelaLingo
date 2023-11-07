using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Courses;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Extensions;
using JelaLingo.Service.Interfaces.Courses;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Course> _courseRepository;

    public CourseService(IMapper mapper, IRepository<Course> courseRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task<CourseForResultDto> AddAsync(CourseForCreationDto dto)
    {
        var courses = await _courseRepository.SelectAll()
            .Where(c => c.Title.ToLower() == dto.Title.ToLower())
            .FirstOrDefaultAsync();

        if (courses is not null)
            throw new JelalingoException(409, "Course is alredy exists");

        var course = _mapper.Map<Course>(dto);
        course.CreatedAt = DateTime.UtcNow;

        var createdCourse = await _courseRepository.InsertAsync(course);
        return _mapper.Map<CourseForResultDto>(createdCourse);
    }

    public async Task<IEnumerable<CourseForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var courses = await _courseRepository.SelectAll()
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseForResultDto>>(courses);
    }

    public async Task<CourseForResultDto> RetrieveByIdAsync(long id)
    {
        var course = await _courseRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
        if (course == null)
            throw new JelalingoException(404, "Course not found");

        return _mapper.Map<CourseForResultDto>(course);
    }

    public async Task<CourseForResultDto> ModifyAsync(long id, CourseForUpdateDto dto)
    {
        var course = await _courseRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (course is null)
            throw new JelalingoException(404, "Course not found");

        course.UpdatedAt = DateTime.UtcNow;
        var mappedCourse = _mapper.Map(dto, course);

        await _courseRepository.UpdateAsync(mappedCourse);

        return _mapper.Map<CourseForResultDto>(mappedCourse);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var course = await _courseRepository.SelectAll()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();

        if (course == null)
            throw new JelalingoException(404, "Course not found");

        await _courseRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<CourseForResultDto>> GetAllAsync()
    {
        var courses = await _courseRepository.SelectAll()
            .ToListAsync();

        return _mapper.Map<IEnumerable<CourseForResultDto>>(courses);
    }
}
