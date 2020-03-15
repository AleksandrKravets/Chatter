using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using Chatter.WebUI.Models.Chat;
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
        public async Task<IActionResult> Create([FromBody]CreateChatViewModel model)
        {
            return Ok(await _chatService.CreateAsync(new Chat
            {
                Name = model.Name,
                /*ChatTypeId = model.ChatTypeId,*/
                ChatType = (ChatType)model.ChatType,
                CreatorId = model.CreatorId
            }));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody]UpdateChatViewModel model)
        {
            return Ok(await _chatService.UpdateAsync(new Chat
            {
                Id = model.Id,
                Name = model.Name,
                CreatorId = model.CreatorId,
                //ChatTypeId = model.ChatTypeId
                ChatType = (ChatType)model.ChatType
            }));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _chatService.DeleteAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Join([FromBody]JoinChatViewModel model) 
        {
            return Ok(await _chatService.JoinChatAsync(model.ChatId, model.UserId));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Leave([FromBody]LeaveChatViewModel model)
        {
            return Ok(await _chatService.LeaveChatAsync(model.ChatId, model.UserId));
        }
    }
}