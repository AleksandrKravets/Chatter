using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Chatter.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<bool> CheckIfUserExistAsync(string nickname, string email)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_CreateUser", connection);
                await connection.OpenAsync();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nickname", user.Nickname);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Id", userId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<User> GetAsync(int userId)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GetUserById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Nickname = reader["Nickname"].ToString();
                    user.HashedPassword = reader["HashedPassword"].ToString();
                    user.Email = reader["Email"].ToString();
                }
            }

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SP_GetUserByEmail", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", email);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Nickname = reader["Nickname"].ToString();
                    user.HashedPassword = reader["HashedPassword"].ToString();
                    user.Email = reader["Email"].ToString();
                }
            }

            return user;
        }

        public Task<User> GetByNicknameAsync(string nickname)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_UpdateUserAccount", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Nickname", user.Nickname);
                command.Parameters.AddWithValue("@Email", user.Email);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
