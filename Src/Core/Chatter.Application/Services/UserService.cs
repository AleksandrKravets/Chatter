using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Users;
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

        public Task CreateAsync(CreateUserModel model)
        {
            return _userRepository.CreateAsync(new CreateUserDto 
            { 
                Email = model.Email, 
                HashedPassword = model.Password + "hash",
                Nickname = model.Nickname 
            });
        }
    }
}
