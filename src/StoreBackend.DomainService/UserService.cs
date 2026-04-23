using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Infrastructure.Repositories;

namespace StoreBackend.DomainService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }

    public Task<User?> GetByIdAsync(Guid externalId)
    {
        return _userRepository.GetByIdAsync(externalId);
    }

    public Task<User> AddAsync(UserDto user)
    {
        var userEntity = new User
        {
            ExternalId = user.ExternalId,
            Username = user.Username,
            Email = user.Email,
            Passwordhash = user.Passwordhash
        };
        return _userRepository.AddAsync(userEntity);
    }

    public async Task DeleteAsync(Guid externalId)
    {
        var user = await _userRepository.GetByIdAsync(externalId);
        if (user == null) throw new ResourceNotFoundException();
        await _userRepository.DeleteAsync(user);
    }
}