using Chatter.Infrastructure.Contexts;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Chatter.Domain.Entities;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ChatHub> _chat;

        public MessageController(ApplicationDbContext context, IHubContext<ChatHub> chat)
        {
            _context = context;
            _chat = chat;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageViewModel model)
        {
            var Message = new Message
            {
                Text = model.Text,
                TimeStamp = DateTime.Now,
                ChatId = model.ChatId
            };

            _context.Messages.Add(Message);

            await _context.SaveChangesAsync();

            return Ok();
        }

        public async Task<IActionResult> SendMessage(CreateMessageViewModel model,
    string roomName)
        {
            var _message = new Message
            {
                ChatId = model.ChatId,
                Text = model.Text,
                TimeStamp = DateTime.Now
            };

            _context.Messages.Add(_message);

            await _context.SaveChangesAsync();

            await _chat.Clients.Group(roomName)
                .SendAsync("ReceiveMessage", new {
                    Text = _message.Text,
                    Timestamp = _message.TimeStamp.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }
    }
}
