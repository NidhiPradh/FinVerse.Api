using FinVerse.Infrastructure.Data;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static FinVerse.Infrastructure.models.ConvertedCurrencyEntity;

namespace FinVerse.Infrastructure.Repository
{
    public class ExchangeRatesRepository : IExchangeRatesRepository
    {
        private readonly IDBExecutor _dbexecutor;
        public ExchangeRatesRepository(IDBExecutor dbexecutor) 
        {
            _dbexecutor = dbexecutor;
        }

        public async Task<CurrencyConversionEntity> CurrencyValueConversion(CurrencyNameEntity currencyName)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@baseCode", currencyName.CurrencyCode),
                new SqlParameter("@targetCode", currencyName.TargetCurrencyCode)
                
            };
            var result = await _dbexecutor.ExecuteReaderAsync<CurrencyConversionEntity>(
            "SP_GetConvertedValue",
            reader => new CurrencyConversionEntity
            {
                BaseCurrency = reader["BaseValue"] as Decimal? ?? default(decimal),
                TargetCurrency = reader["TargetValue"] as Decimal? ?? default(decimal)

            },
            parameters);
            return result.FirstOrDefault();
            //string currencyCode = "USD"; // Default to USD if currencyName is null
            //if(currencyName.CurrencyCode == "USD")
            //{
            //    currencyCode = currencyName.TargetCurrencyCode;
            //}
            //else
            //{
            //    currencyCode = currencyName.CurrencyCode;
            //}
            //    string sql = "SELECT ExchangeRate FROM ExchangeRates WHERE TargetCurrency = @CurrencyCode";
            //var parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@CurrencyCode", currencyCode)
            //};
            //var result = await _dbexecutor.ExecuteScalarInLineQueryAsync<decimal>(sql, parameters);
            // return result;


        }

        public async Task<IList<CurrencyNameEntity>> GetAllCurrencyAsync()
        {
            string JsonCurrencyString = await ReadCurrencyJsonAsync();
            IList<CurrencyNameEntity> currencies = JsonSerializer.Deserialize<List<CurrencyNameEntity>>(JsonCurrencyString)!;
            CurrencyNameEntity currencyNameEntity = new CurrencyNameEntity();
            for (int i = 0;i<currencies.Count; i++)
            {
                currencyNameEntity.targetCurrencyName = currencies[i].CurrencyCode;
                
            }

            return currencies;

        }

        public async Task<int?> InsertExchangeRates(ExchangeRatesEntity ex)
        {
            SqlParameter[] parameters =
             {
                new SqlParameter("@BaseCurrency", ex.BaseCurrency),

                new SqlParameter("@TargetCurrency", ex.TargetCurrency),

                new SqlParameter("@ExchangeRate", ex.ExchangeRateValue),

                new SqlParameter("@ApiLastUpdated", ex.LastUpdated)
            };

            return await _dbexecutor.ExecuteNonQueryAsync(
                "SP_InsertExchangeRate",
                parameters);
        }

        public async Task<string> ReadCurrencyJsonAsync()
        {
            try
            {
                //
                var assemblyPath = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location
                );

                var filePath = Path.Combine(
                    assemblyPath!,
                    "JsonFiles",
                    "currency.json"
                );

                var json = await File.ReadAllTextAsync(filePath);

                return json;
                //
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading currency.json: {ex.Message}");
            }
            
        }

    }
}
