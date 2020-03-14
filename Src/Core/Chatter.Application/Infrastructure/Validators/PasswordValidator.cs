using Chatter.Application.Contracts.Validators;

namespace Chatter.Application.Infrastructure.Validators
{
    public class PasswordValidator : IPasswordValidator
    {
        // take validator settings from config
        // chain of responsibility pattern

        public PasswordValidator()
        {

        }

        public bool ValidatePassword(string password)
        {
            return true;
        }
    }
}
