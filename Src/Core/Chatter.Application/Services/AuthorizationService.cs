using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
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

        public async Task<ResponseObject> AuthorizeAsync(LoginRequestModel model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);

            if(user != null)
            {
                if (SecurePasswordHasher.Verify(model.Password, user.HashedPassword))
                {
                    var tokens = await _tokenService.GetTokensAsync(user);

                    return new ResponseObject 
                    { 
                        Result = tokens,
                        Status = ResponseStatus.Success 
                    };
                }
            }

            return new ResponseObject 
            { 
                Result = null,
                Status = ResponseStatus.Failure 
            };
        }
    }
}
