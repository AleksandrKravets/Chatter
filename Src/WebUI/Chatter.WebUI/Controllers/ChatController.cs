using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Chats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/chats")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _chatService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{pageIndex}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageIndex, int pageSize)
        {
            var result = await _chatService.GetAsync(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _chatService.GetAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody]CreateChatModel model)
        {
            await _chatService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateChatModel model)
        {
            await _chatService.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _chatService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("{chatId}/join/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Join(int chatId, int userId) 
        {
            await _chatService.JoinChatAsync(chatId, userId);
            return Ok();
        }

        [HttpPost]
        [Route("{chatId}/leave/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Leave(int chatId, int userId)
        {
            await _chatService.LeaveChatAsync(chatId, userId);
            return Ok();
        }
    }
}