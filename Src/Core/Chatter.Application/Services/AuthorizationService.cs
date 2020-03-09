using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> AuthorizeAsync(LoginRequestModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);

            if (user != null)
            {
                if (SecurePasswordHasher.Verify(model.Password, user.HashedPassword))
                {
                    return Result.Ok(user);
                }
            }

            return Result.Failure<User>("User with such email does not exist");
        }
    }
}
