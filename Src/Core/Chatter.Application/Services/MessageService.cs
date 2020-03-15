﻿using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Infrastructure;
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

        public async Task<IResponse> CreateAsync(Message message)
        {
            // create message text validator

            if(message.Text.Length > 0)
            {
                var chat = await _chatRepository.GetAsync(message.ChatId);

                if (chat != null)
                {
                    var chatUser = await _chatUserRepository.GetChatUserByKeysAsync(message.ChatId, message.SenderId);

                    if (chatUser != null)
                    {
                        var rowsAffected = await _messageRepository.CreateAsync(message);

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

        public async Task<IResponse> UpdateAsync(Message message)
        {
            var storedMessage = await _messageRepository.GetAsync(message.Id);

            if(storedMessage != null)
            {
                if(message.ChatId == storedMessage.ChatId && message.SenderId == storedMessage.SenderId)
                {
                    var chatUser = await _chatUserRepository.GetChatUserByKeysAsync(message.ChatId, message.SenderId);

                    if (chatUser != null)
                    {
                        var rowsAffected = await _messageRepository.UpdateAsync(message);

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
