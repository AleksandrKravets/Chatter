﻿using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);
        Task<User> GetAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        Task<User> Login(string email, string password);
        Task<bool> CheckPassword(User user, string password);
    }
}
