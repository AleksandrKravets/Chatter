using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthorizationService(IUserRepository userRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<Result<TokensResponseModel>> AuthorizeAsync(LoginRequestModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);

            if(user != null)
            {
                if (SecurePasswordHasher.Verify(model.Password, user.HashedPassword))
                {
                    var response = await _tokenService.GetTokensAsync(user);
                    return Result.Ok(response);
                }
            }

            return Result.Failure<TokensResponseModel>("Authorization error.");
        }
    }
}
