using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contexts;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
            };
            
            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            return Ok(chat);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateChatViewModel model)
        {
            var chat = await _context.Chats.FindAsync(model.Id);
            chat.Name = model.Name;
            _context.Chats.Update(chat);
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
            await _chat.Groups.AddToGroupAsync(model.ConnectionId, model.ChatId.ToString());
            //_chat.Clients.Group(model.ChatId.ToString()).SendAsync("New user joined");
            await _chat.Clients.Group(model.ChatId.ToString()).SendCoreAsync("New user joined", null);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Leave(LeaveChatViewModel model)
        {
            await _chat.Groups.RemoveFromGroupAsync(model.ConnectionId, model.ChatId.ToString());
            await _chat.Clients.Group(model.ChatId.ToString()).SendCoreAsync("User left the group", null);
            return Ok();
        }
    }
}