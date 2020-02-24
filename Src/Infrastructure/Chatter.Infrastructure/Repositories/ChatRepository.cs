using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contracts.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IApplicationDbContext _context;

        public ChatRepository(IApplicationDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Chat chat)
        {
            chat.Id = 0;
            await _context.Chats.AddAsync(chat); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int chatId)
        {
            _context.Chats.Remove(new Chat { Id = chatId });
            await _context.SaveChangesAsync();
        }

        public IQueryable<Chat> Get()
        {
            return _context.Chats;
        }

        public async Task<Chat> GetAsync(int id)
        {
            return await _context.Chats.FindAsync(id);
        }

        public async Task UpdateAsync(Chat chat)
        {
            _context.Chats.Update(chat);
            await _context.SaveChangesAsync();
        }
    }
}
