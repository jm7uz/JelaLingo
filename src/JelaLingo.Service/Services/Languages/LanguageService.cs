using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Languages;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Extensions;
using JelaLingo.Service.Interfaces.Languages;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.Languages;

internal class LanguageService : ILanguageService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Language> _languageRepository;

    public LanguageService(IMapper mapper, IRepository<Language> languageRepository)
    {
        _mapper = mapper;
        _languageRepository = languageRepository;
    }

    public async Task<LanguageForResultDto> AddAsync(LanguageForCreationDto dto)
    {
        var languages = await _languageRepository.SelectAll()
            .Where(l => l.Name.ToLower() == dto.Name.ToLower())
            .FirstOrDefaultAsync();
        if (languages is not null)
            throw new JelalingoException(409, "Language is alredy exists");

        var language = _mapper.Map<Language>(dto);
        language.CreatedAt = DateTime.UtcNow;

        var createdLanguage = await _languageRepository.InsertAsync(language);
        return _mapper.Map<LanguageForResultDto>(createdLanguage);
    }

    public async Task<IEnumerable<LanguageForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var pagedLanguages = await _languageRepository.SelectAll()
            .AsNoTracking()
            .OrderBy(l => l.Id)
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LanguageForResultDto>>(pagedLanguages);
    }

    public async Task<LanguageForResultDto> RetrieveByIdAsync(long id)
    {
        var language = await _languageRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
        if (language == null)
            throw new JelalingoException(404, "Language not found");

        return _mapper.Map<LanguageForResultDto>(language);
    }

    public async Task<LanguageForResultDto> ModifyAsync(long id, LanguageForUpdateDto dto)
    {
        var language = await _languageRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
        if (language == null)
            throw new JelalingoException(404, "Language not found");

        language.UpdatedAt = DateTime.UtcNow;
        var mappedLanguage = _mapper.Map(dto, language);

        await _languageRepository.UpdateAsync(mappedLanguage);

        return _mapper.Map<LanguageForResultDto>(mappedLanguage);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var language = await _languageRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();
        if (language == null)
            throw new JelalingoException(404, "Language not found");

        await _languageRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<LanguageForResultDto>> GetAllAsync()
    {
        var languages = await _languageRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<LanguageForResultDto>>(languages);
    }
}
