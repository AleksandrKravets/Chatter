using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Messages;
using Chatter.WebUI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _chat;

        public MessageController(IMessageService messageService, IHubContext<ChatHub> chat)
        {
            _messageService = messageService;
            _chat = chat;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _messageService.GetAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("~/api/chats/{id:int}/messages")]
        public async Task<IActionResult> GetAll(long chatId)
        {
            var response = await _messageService.GetAllAsync(chatId);
            return Ok(response);
        }

        [HttpPost]
        [Route("~/api/chats/{id:int}/messages")]
        public async Task<IActionResult> Create(long id, CreateMessageModel model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest();

            await _messageService.CreateAsync(id, model);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(long id, [FromBody]UpdateMessageModel model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest();

            await _messageService.UpdateAsync(id, model);
            return Ok();
        }
    }
}
