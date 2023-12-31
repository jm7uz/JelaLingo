﻿using JelaLingo.Service.Configurations;
using JelaLingo.Service.DTOs.Users;
using JelaLingo.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace JelaLingo.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
        => Ok(await _userService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _userService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userService.RetrieveByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] UserForUpdateDto dto)
        => Ok(await _userService.ModifyAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _userService.RemoveAsync(id));

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(await _userService.RetrieveByEmailAsync(email));
}
