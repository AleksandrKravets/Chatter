using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository =
                userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public Task CreateAsync(User user)
        {
            return _userRepository.CreateAsync(user);
        }
        
        public Task DeleteAsync(int userId)
        {
            return _userRepository.DeleteAsync(userId);
        }

        public Task<User> GetAsync(int userId)
        {
            return _userRepository.GetAsync(userId);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
        }

        public async Task<User> Login(string email, string password)
        {
            //var user = await _userRepository.GetByEmailAsync(email);

            //if(user != null)
            //{
            //    // login logic
            //}

            return new User { Email = email, Nickname = "alex111", HashedPassword = "fsdfsdfsd", Id = 1 };
        }

        public Task UpdateAsync(User user)
        {
            return _userRepository.UpdateAsync(user);
        }
    }
}
