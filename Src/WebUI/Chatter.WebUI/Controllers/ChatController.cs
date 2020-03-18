using Chatter.Application.Contracts.Services;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _chatService.GetAsync(id));
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            return Ok(await _chatService.GetAsync(pageIndex, pageSize));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatService.GetAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody]CreateChatRequestModel model)
        {
            return Ok(await _chatService.CreateAsync(model));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody]UpdateChatRequestModel model)
        {
            return Ok(await _chatService.UpdateAsync(model));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _chatService.DeleteAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Join([FromBody]JoinChatRequestModel model) 
        {
            return Ok(await _chatService.JoinChatAsync(model));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Leave([FromBody]LeaveChatRequestModel model)
        {
            return Ok(await _chatService.LeaveChatAsync(model));
        }
    }
}