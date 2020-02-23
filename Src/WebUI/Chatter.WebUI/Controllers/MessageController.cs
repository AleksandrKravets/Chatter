using Chatter.Infrastructure.Contexts;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Chatter.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create(CreateMessageViewModel model)
        {
            var Message = new Message
            {
                Text = model.Text,
                TimeStamp = DateTime.Now,
                ChatId = model.ChatId
            };

            _context.Messages.Add(Message);

            await _context.SaveChangesAsync();

            return Ok(Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Messages.Remove(new Message { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetByChatId(int chatId)
        {
            var messages = await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(message);
        }

        //public async Task<IActionResult> SendMessage(CreateMessageViewModel model, string roomName)
        //{
        //    var _message = new Message
        //    {
        //        ChatId = model.ChatId,
        //        Text = model.Text,
        //        TimeStamp = DateTime.Now
        //    };

        //    _context.Messages.Add(_message);

        //    await _context.SaveChangesAsync();

        //    await _chat.Clients.Group(roomName)
        //        .SendAsync("ReceiveMessage", new {
        //            Text = _message.Text,
        //            Timestamp = _message.TimeStamp.ToString("dd/MM/yyyy hh:mm:ss")
        //        });

        //    return Ok();
        //}
    }
}
