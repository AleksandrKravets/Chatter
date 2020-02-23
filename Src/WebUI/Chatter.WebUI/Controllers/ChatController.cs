using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contexts;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ChatHub> _chat;

        public ChatController(ApplicationDbContext context, IHubContext<ChatHub> chat)
        {
            _context = context;
            _chat = chat;
        }

        //[HttpPost]
        //public IActionResult Do()
        //{
        //    _chat.Clients.All.SendAsync("ReceiveMessage", "Hi everyone");
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var chat = await _context.Chats
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(chat);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var chats = await _context.Chats.Include(c => c.Messages).ToListAsync();
            return Ok(chats);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChatViewModel model)
        {
            var chat = new Chat
            {
                Name = model.Name,
                //Type = ChatType.Room
            };

            //chat.Users.Add(new ChatUser
            //{
            //    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
            //    Role = UserRole.Admin
            //});

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            return Ok(chat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // удалять всех юзеров из чата
            _context.Chats.Remove(new Chat { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Join(JoinChatViewModel model) 
        {
            //var chatUser = new ChatUser
            //{
            //    ChatId = model.ChatId,
            //    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
            //    //Role = UserRole.Member
            //};

            //await _context.ChatUsers.AddAsync(chatUser);

            //await _context.SaveChangesAsync();

            await _chat.Groups.AddToGroupAsync(model.ConnectionId, model.RoomName);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Leave(LeaveChatViewModel model)
        {
            //удалять чат из бд
            await _chat.Groups.RemoveFromGroupAsync(model.ConnectionId, model.RoomName);
            return Ok();
        }
    }
}
