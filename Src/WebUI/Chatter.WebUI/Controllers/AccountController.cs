using Chatter.Application.Contracts.Services;
using Chatter.WebUI.Factories.Contracts;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenFactory _tokenFactory;

        public AccountController(IUserService userService, ITokenFactory tokenFactory)
        {
            _userService = userService;
            _tokenFactory = tokenFactory;
        }

        // Вынести логику проверки состояния модели в фильтр
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //await _userService.CreateAsync(new User
            //{
            //    Email = model.Email,
            //    HashedPassword = model.Password,
            //    Nickname = model.Nickname
            //});

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userService.Login(model.Email, model.Password);

            if (user == null)
                return BadRequest();

            var token = _tokenFactory.GetToken(user);

            return Ok(token);
        }
    }
}
