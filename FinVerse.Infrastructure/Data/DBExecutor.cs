using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Data
{
    public class DBExecutor : IDBExecutor
    {
        private readonly string _connectionString;
        public DBExecutor(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> ExecuteNonQueryAsync(string storedProcedure, SqlParameter[] parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                await connection.OpenAsync();

                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<T?> ExecuteScalarAsync<T>(string storedProcedure, SqlParameter[] parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }


                await connection.OpenAsync();

                object result = await command.ExecuteScalarAsync();

                if (result == null || result == DBNull.Value)
                {
                    return default;
                }


                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception ex)
            {
                // Log the exception (you can use any logging framework)
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Rethrow the exception after logging it
            }

        }
        public async Task<T?> ExecuteScalarInLineQueryAsync<T>(string query,SqlParameter[] parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(query, connection)
            {
                CommandType = CommandType.Text
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            await connection.OpenAsync();

            object result = await command.ExecuteScalarAsync();

            if (result == null || result == DBNull.Value)
            {
                return default;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public async Task<List<T>> ExecuteReaderInLineAsync<T>(string query, Func<SqlDataReader, T> map, SqlParameter[] parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.Text
                };

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                await connection.OpenAsync();

                using var reader = await command.ExecuteReaderAsync();

                var result = new List<T>();

                while (await reader.ReadAsync())
                {
                    result.Add(map(reader));
                }

                return result;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


    }
}
