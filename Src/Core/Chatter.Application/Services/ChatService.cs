using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Chats;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IUserRepository _userRepository;

        public ChatService(IChatRepository chatRepository, IChatUserRepository chatUserRepository, 
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _chatUserRepository = chatUserRepository;
            _chatRepository = chatRepository;
        }

        public Task CreateAsync(CreateChatModel model)
        {
            // Check if chat with such name exist
            // Check if user exist
            // Create chat
            // Create ChatUser(userRole - Chat admin)

            return _chatRepository.CreateAsync(model);
        }

        public Task DeleteAsync(int chatId)
        {
            return _chatRepository.DeleteAsync(chatId);
        }

        public Task<ICollection<ChatModel>> GetAsync()
        {
            return _chatRepository.GetAsync();
        }

        public Task<ICollection<ChatModel>> GetAsync(int pageIndex, int pageSize)
        {
            return _chatRepository.GetAsync(pageIndex, pageSize);
        }

        public Task<ChatModel> GetAsync(int chatId)
        {
            return _chatRepository.GetAsync(chatId);
        }

        public async Task JoinChatAsync(int chatId, int userId)
        {
            // Check if chat with such id exist
            // Check if user exist
            // Check if user with such id doesnt ieist in this chat
            // Create ChatUser
            
        }

        public async Task LeaveChatAsync(int chatId, int userId)
        {
            // Check if chat with such id exist
            // Check if user exist
            // Delete chatUser by chatId and userId
        }

        public Task UpdateAsync(int id, UpdateChatModel model)
        {
            return _chatRepository.UpdateAsync(id, model);
        }
    }
}
