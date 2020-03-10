using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace Chatter.DAL.Infrastructure
{
    public class StoredProcedureExecutor
    {
        private readonly string _connectionString;

        public StoredProcedureExecutor(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IEnumerable<PropertyInfo> GetTypeProperties(Type type)
        {
            return type.GetProperties();
        }

        public async Task<IEnumerable<T>> ExecuteListAsync<T>(StoredProcedure storedProcedure)
        {
            ICollection<T> result = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure.ProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();

                foreach (var procedureParam in storedProcedure.ProcedureParams)
                {
                    command.Parameters.AddWithValue(procedureParam.Key, procedureParam.Value);
                }

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    var entity = (T)Activator.CreateInstance(typeof(T));

                    foreach (var entityProperty in GetTypeProperties(entity.GetType()))
                    {
                        entityProperty.SetValue(entity, Convert.ChangeType(reader[entityProperty.Name], entityProperty.PropertyType));
                    }

                    result.Add(entity);
                }
            }

            return result;
        }

        public Task<T> ExecuteOneAsync<T>(StoredProcedure storedProcedure)
        {
            return null;
        }
    }
}
