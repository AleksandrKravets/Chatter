using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contracts.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IApplicationDbContext _context;

        public ChatRepository(IApplicationDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public Task CreateAsync(Chat chat)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int chatId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Chat> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Chat> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Chat chat)
        {
            throw new NotImplementedException();
        }
    }
}
