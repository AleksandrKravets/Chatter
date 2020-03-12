using System;
using System.Data.SqlClient;

namespace Chatter.DAL.Infrastructure
{
    public static class ReaderExtensions
    {
        public static T ReadObject<T>(this SqlDataReader reader)
        {
            var instance = (T)Activator.CreateInstance(typeof(T));

            foreach (var instanceProperty in instance.GetType().GetProperties())
            {
                instanceProperty.SetValue(instance, Convert.ChangeType(reader[instanceProperty.Name], instanceProperty.PropertyType));
            }

            return instance;
        }
    }
}
