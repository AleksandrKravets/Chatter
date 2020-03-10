using Chatter.Application.Contracts.Factories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Helpers;
using Chatter.Common.ConfigurationModels;
using Chatter.Domain.Dto;
using Chatter.WebUI.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly ITokenFactory _tokenFactory;
        private readonly JwtSettings _jwtSettings;

        public AuthorizationController(
            IAuthorizationService authorizationService,
            ITokenFactory tokenFactory, 
            IUserService userService, 
            ITokenService tokenService, 
            IOptions<JwtSettings> jwtSettings)
        {
            _authorizationService = authorizationService;
            _tokenFactory = tokenFactory;
            _tokenService = tokenService;
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorizationResult = await _authorizationService.AuthorizeAsync(model);

            if(authorizationResult.IsSuccess)
            {
                var response = new TokensResponseModel
                {
                    AccessToken = _tokenFactory.GetAccessToken(authorizationResult.Value),
                    RefreshToken = _tokenFactory.GetRefreshToken()
                };


                await _tokenService.RefreshToken(authorizationResult.Value.Id);


                await _tokenService.AddRefreshTokenAsync(new Domain.Entities.RefreshToken 
                { 
                    Token = response.RefreshToken.Token, 
                    UserId = authorizationResult.Value.Id,
                    Expires = response.RefreshToken.Expires
                });
                 
                return Ok(response);
            }

            return BadRequest(model);
        }

        [HttpPost]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var principalResult = JwtHelper.GetPrincipalFromExpiredToken(model.AccessToken, _jwtSettings.SecretKey);

            if(principalResult.IsSuccess)
            {
                var userId = principalResult.Value.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub);

                var user = await _userService.GetAsync(Convert.ToInt32(userId.Value));

                if(user != null)
                {
                    if (_tokenService.HasValidRefreshToken(user.Id, model.RefreshToken))
                    {
                        var response = new TokensResponseModel
                        {
                            AccessToken = _tokenFactory.GetAccessToken(user),
                            RefreshToken = _tokenFactory.GetRefreshToken()
                        };

                        // Объединить методы в RefreshToken
                        await _tokenService.RemoveRefreshTokenAsync(model.RefreshToken);

                        await _tokenService.AddRefreshTokenAsync(new Domain.Entities.RefreshToken
                        {
                            Token = response.RefreshToken.Token,
                            UserId = user.Id,
                            Expires = response.RefreshToken.Expires
                        });

                        return Ok(response);
                    }
                }
            }

            return BadRequest(ModelState);
        }
    }
}
