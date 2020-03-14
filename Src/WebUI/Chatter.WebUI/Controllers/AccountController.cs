using Chatter.Application.Contracts.Services;
using Chatter.Domain.Dto;
using Chatter.WebUI.Filters;
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
        [BadRequestFilter]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequestModel model)
        {
            return Ok(await _accountService.RegisterAsync(model));
        }    
    }
}
