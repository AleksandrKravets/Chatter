using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models.Message;
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

        // надо передавать юзера чтобы проверить состоит ли он в чате ()
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _messageService.GetAsync(id);
            return Ok(response);
        }

        // надо передавать юзера чтобы проверить состоит ли он в чате ()
        [HttpGet("{chatId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByChatId(int chatId)
        {
            var response = await _messageService.GetAllAsync(chatId);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateMessageViewModel model)
        {
            var message = new Message
            {
                Text = model.Text,
                TimeStamp = DateTime.Now,
                ChatId = model.ChatId, 
                SenderId = model.SenderId
            };

            

            /*await _chat.Clients.Group(model.ChatId.ToString())
                .SendAsync("ReceivedMessage", new {
                    Text = model.Text,
                    //Timestamp = model.TimeStamp.ToString("dd/MM/yyyy hh:mm:ss")
                });*/

            return Ok(await _messageService.CreateAsync(message));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            // Отправлять SignalR запрос на удаление сообщения 
            return Ok(await _messageService.DeleteAsync(id));
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody]UpdateMessageRequestModel model)
        {
            // Отправлять SignalR запрос на обновление сообщения 

            return Ok(await _messageService.UpdateAsync(new Message
            {
                Id = model.MessageId,
                Text = model.Text,
                TimeStamp = DateTime.Now,
                SenderId = model.SenderId
            }));
        }

        [HttpGet("{chatId}/{pageIndex}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int chatId, int pageIndex, int pageSize)
        {
            return Ok(await _messageService.GetAsync(chatId, pageIndex, pageSize));
        }
    }

    public class UpdateMessageRequestModel 
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }
    }
}
