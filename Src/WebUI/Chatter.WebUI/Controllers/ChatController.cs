using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IHubContext<ChatHub> _chat;

        public ChatController(IChatService chatService, IHubContext<ChatHub> chat)
        {
            _chatService = chatService;
            _chat = chat;
        }

        [HttpGet("{id}")]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = ...)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var chat = await _chatService.GetAsync(id);
            return Ok(chat);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var chats = await _chatService.GetAsync();
            return Ok(chats);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateChatViewModel model)
        {
            var chat = new Chat
            {
                Name = model.Name,
                Type = ChatType.Room
            };

            await _chatService.CreateAsync(chat);

            return Ok(chat);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateChatViewModel model)
        {
            var chat = new Chat
            {
                Id = model.Id,
                Name = model.Name,
                Type = ChatType.Room
            };

            await _chatService.UpdateAsync(chat);

            return Ok(chat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _chatService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Join(JoinChatViewModel model) 
        {
            await _chat.Groups.AddToGroupAsync(model.ConnectionId, model.ChatId.ToString());
            //_chat.Clients.Group(model.ChatId.ToString()).SendAsync("New user joined");
            await _chat.Clients.Group(model.ChatId.ToString()).SendCoreAsync("New user joined", null);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Leave(LeaveChatViewModel model)
        {
            await _chat.Groups.RemoveFromGroupAsync(model.ConnectionId, model.ChatId.ToString());
            await _chat.Clients.Group(model.ChatId.ToString()).SendCoreAsync("User left the group", null);
            return Ok();
        }
    }
}