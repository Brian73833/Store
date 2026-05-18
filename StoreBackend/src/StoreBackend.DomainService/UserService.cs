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

    public async Task DeleteAsync(Guid externalId)
    {
        var user = await _userRepository.GetByIdAsync(externalId);
        if (user == null) throw new ResourceNotFoundException();
        await _userRepository.DeleteAsync(user);
    }

    public async Task<User> CreateAsync(CreateUserDto user)
    {
        if (await _userRepository.HasUserByUsernameAsync(user.Username))
        {
            throw new Exceptions.BadRequestResponseException("Username is already taken");
        }
        if (await _userRepository.HasUserByEmailAsync(user.Email))
        {
            throw new Exceptions.BadRequestResponseException("Email is already taken");
        }

        var entity = new User
        {
            ExternalId = Guid.NewGuid(),
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
        };
        return await _userRepository.CreateAsync(entity);
    }

}