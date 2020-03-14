using Chatter.Application.Contracts.Services;
using Chatter.Domain.Dto;
using Chatter.WebUI.Filters;
using Chatter.WebUI.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly Application.Contracts.Services.IAuthorizationService _authorizationService;
        private readonly ITokenService _tokenService;

        public AuthorizationController(
            Application.Contracts.Services.IAuthorizationService authorizationService,
            ITokenService tokenService)
        {
            _authorizationService = authorizationService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [BadRequestFilter]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
            return Ok(await _authorizationService.AuthorizeAsync(model));
        }

        [HttpPost]
        [BadRequestFilter]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel model)
        {
            return Ok(await _tokenService.RefreshTokenAsync(model.RefreshToken, model.AccessToken));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Secret()
        {
            return Ok();
        }
    }
}
