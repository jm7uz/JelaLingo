using AutoMapper;
using JelaLingo.Data.IRepositories;
using JelaLingo.Domain.Entities;
using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Users;
using JelaLingo.Service.Exceptions;
using JelaLingo.Service.Extensions;
using JelaLingo.Service.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace JelaLingo.Service.Services.Users
{

    internal class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            var users = await _userRepository.SelectAll()
                .Where(u => u.Email == dto.Email)
                .FirstOrDefaultAsync();
            
            if (users is not null)
                throw new JelalingoException(409, "User is alredy exists");
            
            var mappedUser = _mapper.Map<User>(dto);
            mappedUser.CreatedAt = DateTime.UtcNow;

            var createdUser = await _userRepository.InsertAsync(mappedUser);
            return _mapper.Map<UserForResultDto>(createdUser);
        }

        public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
        {
            var user = await _userRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if (user is null)
                throw new JelalingoException(404, "User not found");

            user.UpdatedAt = DateTime.UtcNow;
            var person = _mapper.Map(dto, user);

            await _userRepository.UpdateAsync(person);

            return _mapper.Map<UserForResultDto>(person);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var user = await _userRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if (user is null)
                throw new JelalingoException(404, "User is not found");

            await _userRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var pagedUsers = await _userRepository.SelectAll()
                .AsNoTracking()
                .OrderBy(u => u.Id)
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserForResultDto>>(pagedUsers);
        }

        public async Task<UserForResultDto> RetrieveByEmailAsync(string email)
        {
            var user = await _userRepository.SelectAll()
                .Where(u => u.Email.ToLower() == email.ToLower())
                .FirstOrDefaultAsync();
            if (user is null)
                throw new JelalingoException(404, "User Not Found");

            return _mapper.Map<UserForResultDto>(user);
        }

        public async Task<UserForResultDto> RetrieveByIdAsync(long id)
        {
            var users = await _userRepository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if (users is null)
                throw new JelalingoException(404, "User is not found");

            return _mapper.Map<UserForResultDto>(users);
        }
    }
}
