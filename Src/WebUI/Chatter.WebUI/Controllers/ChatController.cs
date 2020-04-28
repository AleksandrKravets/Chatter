using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Chats;
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
        public async Task<IActionResult> Get(long id)
        {
            var result = await _chatService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _chatService.GetAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateChatModel model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest();

            await _chatService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody]UpdateChatModel model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest();

            await _chatService.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _chatService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("{chatId}/join/{userId}")]
        public async Task<IActionResult> Join(long chatId, long userId) 
        {
            await _chatService.JoinChatAsync(chatId, userId);
            return Ok();
        }

        [HttpPost]
        [Route("{chatId}/leave/{userId}")]
        public async Task<IActionResult> Leave(long chatId, long userId)
        {
            await _chatService.LeaveChatAsync(chatId, userId);
            return Ok();
        }
    }
}