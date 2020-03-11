using Chatter.Application.Contracts.Services;
using Chatter.Domain.Dto;
using Chatter.WebUI.Filters;
using Chatter.WebUI.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ITokenService _tokenService;

        public AuthorizationController(
            IAuthorizationService authorizationService,
            ITokenService tokenService)
        {
            _authorizationService = authorizationService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [BadRequestFilter]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
            var response = await _authorizationService.AuthorizeAsync(model);

            if(response.IsSuccess)
                return Ok(response.Value);

            return BadRequest(model);
        }

        // Если сервер возвращает 401 -> токен протух
        [HttpPost]
        [BadRequestFilter]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel model)
        {
            var result = await _tokenService.RefreshTokenAsync(model.RefreshToken, model.AccessToken);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(result.Error);
        }
    }
}
