using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChatUserRepository _chatUserRepository;

        public MessageService(
            IMessageRepository messageRepository, 
            IChatRepository chatRepository,
            IUserRepository userRepository,
            IChatUserRepository chatUserRepository)
        {
            _chatRepository = chatRepository;
            _chatUserRepository = chatUserRepository;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public async Task<IResponse> CreateAsync(CreateMessageRequestModel model)
        {
            // create message text validator

            if(model.Text.Length > 0)
            {
                var chat = await _chatRepository.GetAsync(model.ChatId);

                if (chat != null)
                {
                    var chatUser = await _chatUserRepository.GetChatUserByKeysAsync(model.ChatId, model.SenderId);

                    if (chatUser != null)
                    {
                        var rowsAffected = await _messageRepository.CreateAsync(new Message 
                        { 
                            Id = 0,
                            ChatId = model.ChatId,
                            SenderId = model.SenderId,
                            Text = model.Text,
                            TimeStamp = DateTime.Now 
                        });

                        return new BaseResponse 
                        { 
                            Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure 
                        };
                    }
                }
            }

            return new BaseResponse 
            { 
                Status = ResponseStatus.Failure 
            };
        }

        public async Task<IResponse> DeleteAsync(int messageId)
        {
            var rowsAffected = await _messageRepository.DeleteAsync(messageId);

            return new BaseResponse
            {
                Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure
            };
        }

        public async Task<IResponse> GetAsync(int messageId)
        {
            var message = await _messageRepository.GetAsync(messageId);

            if (message == null)
                return new BaseResponse 
                { 
                    Status = ResponseStatus.Failure
                };

            return new ResponseObject 
            { 
                Result = message, 
                Status = ResponseStatus.Success 
            };
        }

        public async Task<IResponse> UpdateAsync(UpdateMessageRequestModel model)
        {
            var storedMessage = await _messageRepository.GetAsync(model.Id);

            if(storedMessage != null)
            {
                if(model.ChatId == storedMessage.ChatId && model.SenderId == storedMessage.SenderId)
                {
                    var chatUser = await _chatUserRepository.GetChatUserByKeysAsync(model.ChatId, model.SenderId);

                    if (chatUser != null)
                    {
                        var rowsAffected = await _messageRepository.UpdateAsync(new Message 
                        { 
                            Id = model.Id,
                            ChatId = model.ChatId,
                            Text = model.Text,
                            SenderId = model.SenderId,
                            TimeStamp = DateTime.Now
                        });

                        return new BaseResponse
                        {
                            Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure
                        };
                    }
                }
            }

            return new BaseResponse
            {
                Status = ResponseStatus.Failure
            };
        }

        public Task<IResponse> GetAsync(int chatId, int pageIndex, int pageSize)
        {
            //// like in chat service
            //var chat = await _chatRepository.GetAsync(chatId);

            //if (chat != null)
            //{
            //    _messageRepository.Get
            //    var chatUser = await _chatUserRepository.GetChatUserByKeysAsync(message.ChatId, message.SenderId);

            //    if (chatUser != null)
            //    {
            //        var rowsAffected = await _messageRepository.CreateAsync(message);

            //        return new BaseResponse
            //        {
            //            Status = rowsAffected > 0 ? ResponseStatus.Success : ResponseStatus.Failure
            //        };
            //    }
            //}
            //return null;
            throw new NotImplementedException();
        }

        public async Task<IResponse> GetAllAsync(int chatId)
        {
            // надо передавать юзера чтобы проверить состоит ли он в чате 
            var chat = await _chatRepository.GetAsync(chatId);

            if (chat != null)
            {
                var messages = await _messageRepository.GetAllAsync(chatId);

                return new ResponseObject
                {
                    Result = messages,
                    Status = ResponseStatus.Success
                };
            }

            return new BaseResponse
            {
                Status = ResponseStatus.Failure
            };
        }
    }
}
