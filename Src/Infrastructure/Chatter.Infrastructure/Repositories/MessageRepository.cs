using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contracts.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IApplicationDbContext _context;

        public MessageRepository(IApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public Task CreateAsync(Message message)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int messageId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Message> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Message> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}
