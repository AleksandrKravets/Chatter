using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly string _connectionString;

        public ChatRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateAsync(Chat chat)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_AddChat", connection);
                await connection.OpenAsync();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", chat.Name);
                command.Parameters.AddWithValue("@ChatType", chat.Type);
                command.ExecuteNonQuery();
            }
        }

        public async Task DeleteAsync(int chatId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_DeleteChat", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Id", chatId);
                command.ExecuteNonQuery();
            }
        }

        public async Task<IEnumerable<Chat>> GetAllAsync()
        {
            List<Chat> chats = new List<Chat>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GetChats", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var chat = new Chat()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Type = (ChatType)Convert.ToInt32(reader["ChatType"])
                    };
                    chats.Add(chat);
                }
            }

            return chats;
        }

        public async Task<Chat> GetAsync(int id)
        {
            Chat chat = new Chat();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GetChatById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ChatId", id);
                await connection.OpenAsync();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    chat.Id = Convert.ToInt32(reader["Id"]);
                    chat.Name = reader["Name"].ToString();
                    chat.Type = (ChatType)Convert.ToInt32(reader["ChatType"]);
                }
            }

            return chat;
        }

        public async Task UpdateAsync(Chat chat)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_UpdateChat", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Id", chat.Id);
                command.Parameters.AddWithValue("@Name", chat.Name);
                command.Parameters.AddWithValue("@ChatType", chat.Type);
                command.ExecuteNonQuery();
            }
        }
    }
}
