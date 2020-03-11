using Chatter.Application.Contracts.Services;
using Chatter.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
