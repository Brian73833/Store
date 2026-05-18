using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid externalId);
    Task DeleteAsync(Guid externalId);
    Task<User> CreateAsync(CreateUserDto user);
}