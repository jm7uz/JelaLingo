using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.DTOs.UserLanguages;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Interfaces.UserLanguages;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.UserLanguages;

internal class UserLanguageService : IUserLanguageService
{
    private readonly IMapper _mapper;
    private readonly IRepository<UserLanguage> _userLanguageRepository;

    public UserLanguageService(IMapper mapper, IRepository<UserLanguage> userLanguageRepository)
    {
        _mapper = mapper;
        _userLanguageRepository = userLanguageRepository;
    }

    public async Task<UserLanguageForResultDto> AddAsync(UserLanguageForCreationDto dto)
    {
        var existingUserLanguage = await _userLanguageRepository.SelectAll()
            .Where(ul => ul.UserId == dto.UserId && ul.LanguageId == dto.LanguageId)
            .FirstOrDefaultAsync();

        if (existingUserLanguage != null)
            throw new JelalingoException(409, "User already has this language");

        var userLanguage = _mapper.Map<UserLanguage>(dto);
        userLanguage.CreatedAt = DateTime.UtcNow;

        var createdUserLanguage = await _userLanguageRepository.InsertAsync(userLanguage);
        return _mapper.Map<UserLanguageForResultDto>(createdUserLanguage);
    }

    public async Task<bool> RemoveAsync(long userLanguageId)
    {
        var userLanguage = await _userLanguageRepository.SelectAll()
            .Where(ul => ul.Id == userLanguageId)
            .FirstOrDefaultAsync();
        if (userLanguage == null)
            throw new JelalingoException(404, "UserLanguage not found");

        await _userLanguageRepository.DeleteAsync(userLanguageId);

        return true;
    }

    public async Task<UserLanguageForResultDto> RetrieveByIdAsync(long userLanguageId)
    {
        var userLanguage = await _userLanguageRepository.SelectAll()
            .Where(ul => ul.Id == userLanguageId)
            .FirstOrDefaultAsync();
        if (userLanguage == null)
            throw new JelalingoException(404, "UserLanguage not found");

        return _mapper.Map<UserLanguageForResultDto>(userLanguage);
    }
    public async Task<IEnumerable<UserLanguageForResultDto>> GetAllAsync()
    {
        var userLanguages = await _userLanguageRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<UserLanguageForResultDto>>(userLanguages);
    }
}
