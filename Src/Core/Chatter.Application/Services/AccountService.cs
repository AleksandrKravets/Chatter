using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> RegisterAsync(RegisterRequestModel model)
        {
            if(!await _userRepository.CheckIfUserExistAsync(model.Nickname, model.Email))
            {
                await _userRepository.CreateAsync(new User
                {
                    Nickname = model.Nickname,
                    Email = model.Email,
                    HashedPassword = SecurePasswordHasher.Hash(model.Password)
                });

                return Result.Ok();
            }

            return Result.Failure("User with such data exists");
        }
    }
}
