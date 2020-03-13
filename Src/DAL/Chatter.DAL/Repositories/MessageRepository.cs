using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.Messages;
using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public MessageRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task CreateAsync(Message message)
        {
            return _procedureExecutor.ExecuteAsync(new CreateMessageSP
            {
                Text = message.Text, 
                TimeStamp = message.TimeStamp, 
                ChatId = message.ChatId
            });
        }

        public Task DeleteAsync(int messageId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteMessageSP
            {
                Id = messageId
            });
        }

        public Task<IEnumerable<Message>> GetAllAsync(int chatId)
        {
            return _procedureExecutor.ExecuteListAsync<Message>(new GetMessagesByChatIdSP 
            { 
                ChatId = chatId    
            });
        }

        public Task<Message> GetAsync(int id)
        {
            return _procedureExecutor.ExecuteOneAsync<Message>(new GetMessageByIdSP 
            { 
                MessageId = id 
            });
        }

        public Task UpdateAsync(Message message)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateMessageSP 
            {
                Id = message.Id,
                Text = message.Text,
                TimeStamp = message.TimeStamp,
                ChatId = message.ChatId
            });
        }
    }
}
