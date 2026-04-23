using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid externalId);
    Task<User> AddAsync(UserDto user);
    Task DeleteAsync(Guid externalId);
}