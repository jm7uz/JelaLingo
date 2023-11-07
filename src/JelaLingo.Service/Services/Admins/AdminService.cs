using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Admins;
using JelaLingo.Service.DTOs.Users;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Extensions;
using JelaLingo.Service.Interfaces.Admins;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.Admins;

public class AdminService : IAdminService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Admin> _adminRepository;
    public AdminService(IMapper mapper, IRepository<Admin> userRepository)
    {
        _mapper = mapper;
        _adminRepository = userRepository;
    }
    public async Task<AdminForResultDto> AddAsync(AdminForCreationDto dto)
    {
        var admins = await _adminRepository.SelectAll()
                .Where(a => a.Email == dto.Email)
                .FirstOrDefaultAsync();

        if (admins is not null)
            throw new JelalingoException(409, "User is alredy exists");

        var mappedAdmin = _mapper.Map<Admin>(dto);
        mappedAdmin.CreatedAt = DateTime.UtcNow;

        var createdAdmin = await _adminRepository.InsertAsync(mappedAdmin);
        return _mapper.Map<AdminForResultDto>(createdAdmin);
    }

    public async Task<AdminForResultDto> ModifyAsync(long id, AdminForUpdateDto dto)
    {
        var admin = await _adminRepository.SelectAll()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        if (admin is null)
            throw new JelalingoException(404, "User not found");

        admin.UpdatedAt = DateTime.UtcNow;
        var person = _mapper.Map(dto, admin);

        await _adminRepository.UpdateAsync(person);

        return _mapper.Map<AdminForResultDto>(person);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var admin = await _adminRepository.SelectAll()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        if (admin is null)
            throw new JelalingoException(404, "User is not found");

        await _adminRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<AdminForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var pagedAdmins = await _adminRepository.SelectAll()
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .ToPagedList(@params)
                .ToListAsync();

        return _mapper.Map<IEnumerable<AdminForResultDto>>(pagedAdmins);
    }

    public async Task<AdminForResultDto> RetrieveByEmailAsync(string email)
    {
        var admin = await _adminRepository.SelectAll()
                .Where(a => a.Email.ToLower() == email.ToLower())
                .FirstOrDefaultAsync();
        if (admin is null)
            throw new JelalingoException(404, "User Not Found");

        return _mapper.Map<AdminForResultDto>(admin);
    }

    public async Task<AdminForResultDto> RetrieveByIdAsync(long id)
    {
        var admins = await _adminRepository.SelectAll()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        if (admins is null)
            throw new JelalingoException(404, "User is not found");

        return _mapper.Map<AdminForResultDto>(admins);
    }
}
