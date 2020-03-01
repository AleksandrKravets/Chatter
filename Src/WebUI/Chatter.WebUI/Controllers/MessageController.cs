using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _chat;

        public MessageController(IMessageService messageService, IHubContext<ChatHub> chat)
        {
            _messageService = messageService;
            _chat = chat;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var message = await _messageService.GetAsync(id);
            return Ok(message);
        }

        [HttpGet("{chatId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByChatId(int chatId)
        {
            var messages = await _messageService.GetAllAsync(chatId);
            return Ok(messages);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateMessageViewModel model)
        {
            var message = new Message
            {
                Text = model.Text,
                TimeStamp = DateTime.Now,
                ChatId = model.ChatId
            };

            await _messageService.CreateAsync(message);

            await _chat.Clients.Group(model.ChatId.ToString())
                .SendAsync("ReceivedMessage", new {
                    Text = model.Text,
                    //Timestamp = model.TimeStamp.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
        }
    }
}
