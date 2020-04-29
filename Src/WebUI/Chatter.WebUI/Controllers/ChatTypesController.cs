using Chatter.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chatter.API.Controllers
{
    [Route("api/chat-types")]
    public class ChatTypesController : Controller
    {
        private readonly IChatTypeService _chatTypeService;

        public ChatTypesController(IChatTypeService chatTypeService)
        {
            _chatTypeService = chatTypeService ?? throw new ArgumentNullException(nameof(chatTypeService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _chatTypeService.GetAllAsync();
            return Ok(result);
        }
    }
}
