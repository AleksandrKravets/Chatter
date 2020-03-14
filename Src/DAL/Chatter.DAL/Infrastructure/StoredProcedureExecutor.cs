using Chatter.Common.ConfigurationModels;
using Chatter.DAL.Infrastructure.Attributes;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Chatter.DAL.Infrastructure
{
    public class StoredProcedureExecutor
    {
        private readonly DatabaseSettings _settings;

        public StoredProcedureExecutor(IOptions<DatabaseSettings> options)
        {
            _settings = options.Value;
        }

        private string GetStoredProcedureName(StoredProcedure storedProcedure)
        {
            var nameAttribute = (ProcedureName)storedProcedure.GetType().GetCustomAttributes(typeof(ProcedureName)).FirstOrDefault();

            if (nameAttribute == null)
                return storedProcedure.GetType().Name;

            return nameAttribute.Name;
        }

        private IEnumerable<FieldInfo> GetTypeFields(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.SetField |
                BindingFlags.GetField | BindingFlags.Instance)
                .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(InParameter)));
        }

        private void AddParametersToCommand(SqlCommand command, IEnumerable<FieldInfo> fields, StoredProcedure storedProcedure)
        {
            foreach (var property in fields)
            {
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(storedProcedure));
            }
        }

        private SqlCommand CreateSqlCommand(StoredProcedure storedProcedure, SqlConnection connection, IEnumerable<FieldInfo> fields)
        {
            var storedProcedureName = GetStoredProcedureName(storedProcedure);
            var command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            AddParametersToCommand(command, fields, storedProcedure);
            return command;
        }


        public async Task<IEnumerable<T>> ExecuteListAsync<T>(StoredProcedure storedProcedure)
        {
            var fields = GetTypeFields(storedProcedure.GetType());
            var result = new List<T>();

            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                SqlCommand command = CreateSqlCommand(storedProcedure, connection, fields);

                await connection.OpenAsync();

                using(var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var instance = reader.ReadObject<T>();
                        result.Add(instance);
                    }

                    reader.Close();
                }
            }

            return result;
        }

        public async Task ExecuteAsync(StoredProcedure storedProcedure)
        {
            var fields = GetTypeFields(storedProcedure.GetType());

            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = CreateSqlCommand(storedProcedure, connection, fields);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<T> ExecuteOneAsync<T>(StoredProcedure storedProcedure)
        {
            var fields = GetTypeFields(storedProcedure.GetType());
            var result = (T)Activator.CreateInstance(typeof(T));

            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                SqlCommand command = CreateSqlCommand(storedProcedure, connection, fields);

                await connection.OpenAsync();

                using(var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        result = reader.ReadObject<T>();
                    }

                    reader.Close();
                }
            }

            return result;
        }
    }
}
