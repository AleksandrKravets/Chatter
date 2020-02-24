using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contracts.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IApplicationDbContext _context;

        public MessageRepository(IApplicationDbContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Message message)
        {
            message.Id = 0;
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int messageId)
        {
            _context.Messages.Remove(new Message { Id = messageId });
            await _context.SaveChangesAsync();
        }

        public IQueryable<Message> Get(int chatId)
        {
            return _context.Messages.Where(message => message.ChatId == chatId);
        }

        public async Task<Message> GetAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task UpdateAsync(Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
