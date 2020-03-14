using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Contracts.Validators;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;

        public AccountService(IUserRepository userRepository, IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
        }

        public async Task<IResponse> RegisterAsync(RegisterRequestModel model)
        {
            var user = await _userRepository.GetAsync(model.Nickname, model.Email);

            if(user == null)
            {
                if (_passwordValidator.ValidatePassword(model.Password))
                {
                    var hashedPassword = SecurePasswordHasher.Hash(model.Password);

                    var rowsAffected = await _userRepository.CreateAsync(new User
                    {
                        Nickname = model.Nickname,
                        Email = model.Email,
                        HashedPassword = hashedPassword
                    });

                    return new BaseResponse
                    {
                        Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure
                    };
                }
            }

            return new BaseResponse
            {
                Status = ResponseStatus.Failure
            };
        }
    }
}
