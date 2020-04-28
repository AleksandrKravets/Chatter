using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Account;
using Chatter.Domain.Dto;
using Chatter.WebUI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel model)
        {
            await _accountService.RegisterAsync(model);
            return Ok();
        }    
    }
}
