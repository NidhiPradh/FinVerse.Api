using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Data
{
    public interface IDBExecutor
    {
        Task<int> ExecuteNonQueryAsync(string storedProcedure, SqlParameter[] parameters = null);
        Task<T?> ExecuteScalarAsync<T>(string storedProcedure, SqlParameter[] parameters = null);
        Task<T?> ExecuteScalarInLineQueryAsync<T>(string query, SqlParameter[] parameters = null);
        Task<List<T>> ExecuteReaderInLineAsync<T>(string storedProcedure, Func<SqlDataReader, T> map, SqlParameter[] parameters = null);


    }
}
