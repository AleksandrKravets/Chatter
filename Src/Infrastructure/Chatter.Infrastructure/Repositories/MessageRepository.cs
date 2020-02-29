using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly string _connectionString;

        public MessageRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateAsync(Message message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_CreateMessage", connection);
                await connection.OpenAsync();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Text", message.Text);
                command.Parameters.AddWithValue("@DateTime", message.TimeStamp);
                command.Parameters.AddWithValue("@ChatId", message.ChatId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int messageId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_DeleteMessage", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Id", messageId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<Message>> GetAllAsync(int chatId)
        {
            List<Message> messages = new List<Message>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GetMessagesByChatId", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@ChatId", chatId);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var message = new Message()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Text = reader["Text"].ToString(),
                        TimeStamp = (DateTime)reader["DateTime"],
                        ChatId = Convert.ToInt32(reader["ChatId"])
                    };
                    messages.Add(message);
                }
            }

            return messages;
        }

        public async Task<Message> GetAsync(int id)
        {
            Message message = new Message();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GetMessageById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MessageId", id);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    message.Id = Convert.ToInt32(reader["Id"]);
                    message.Text = reader["Text"].ToString();
                    message.TimeStamp = (DateTime)reader["DateTime"];
                    message.ChatId = Convert.ToInt32(reader["ChatId"]);
                }
            }

            return message;
        }

        public async Task UpdateAsync(Message message)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_UpdateMessage", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Id", message.Id);
                command.Parameters.AddWithValue("@Text", message.Text);
                command.Parameters.AddWithValue("@DateTime", message.TimeStamp);
                command.Parameters.AddWithValue("@ChatId", message.ChatId);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
