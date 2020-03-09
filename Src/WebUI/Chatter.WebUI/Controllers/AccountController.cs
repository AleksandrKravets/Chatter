using Chatter.Application.Contracts.Services;
using Chatter.Domain.Dto;
using Chatter.WebUI.Factories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenFactory _tokenFactory;

        public AccountController(IAccountService accountService, ITokenFactory tokenFactory)
        {
            _accountService = accountService;
            _tokenFactory = tokenFactory;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if((await _accountService.RegisterAsync(model)).IsSuccess)
                return Ok();

            return BadRequest(model);
        }    
    }
}
