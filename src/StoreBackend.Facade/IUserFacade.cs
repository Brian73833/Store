using System;
using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface IUserFacade
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(Guid externalId);
    Task<UserDto> AddAsync(UserDto user);
    Task DeleteAsync(Guid externalId);
}