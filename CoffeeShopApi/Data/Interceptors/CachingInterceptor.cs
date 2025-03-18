using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;

namespace CoffeeShopApi.Data.Interceptors
{
    public class CachingInterceptor:DbCommandInterceptor
    {
        private readonly IMemoryCache _cache;
        private const string CacheVersionKey = "GlobalCacheVersion";
        private bool band = false;
        public CachingInterceptor(IMemoryCache cache)
        {
            _cache = cache;
        }

        private int GetCacheVersion()
        {
            if (!_cache.TryGetValue(CacheVersionKey, out int version))
            {
                version = 0;
                _cache.Set(CacheVersionKey, version);
            }
            return version;
        }

        private void IncrementCacheVersion()
        {
            int version = GetCacheVersion();
            _cache.Set(CacheVersionKey, version + 1);
        }

        private bool IsSelectCommand(DbCommand command)
        {
            // Verificar si el comando es una consulta SELECT
            return command.CommandText.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase);
        }



        private string GenerateCacheKey(DbCommand command)
        {
            int version = GetCacheVersion();
            string commandText = command.CommandText;
            string parameters = string.Join(",", command.Parameters.Cast<DbParameter>().Select(p => p.Value));

            return $"{version}:{commandText}:{parameters}";
        }


        //Leyendo de la Cache
        public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
        {
            Console.WriteLine(command.CommandText);
            if (IsSelectCommand(command))
            {
                string key = GenerateCacheKey(command);

                if (_cache.TryGetValue(key, out List<Dictionary<string, object>>? cacheEntry))
                {
                    DataTable table = new DataTable();
                    if (cacheEntry != null && cacheEntry.Any())
                    {
                        Console.WriteLine("Read from cache");

                        foreach (var pair in cacheEntry.First())
                        {
                            table.Columns.Add(pair.Key, pair.Value is not null && pair.Value?.GetType() != typeof(DBNull)
                                ? pair.Value!.GetType() : typeof(object));
                        }

                        foreach (var row in cacheEntry)
                        {
                            table.Rows.Add(row.Values.ToArray());
                        }

                        DataTableReader reader = table.CreateDataReader();
                        return InterceptionResult<DbDataReader>.SuppressWithResult(reader);
                    }

                }
            }
            else
            {
                if (band)
                {
                    IncrementCacheVersion();
                    band = false;
                    Console.WriteLine("Version de Cache Incrementada");
                }
                
            }

                return result;
        }

        //Escribiendo de la cache
        public override async ValueTask<DbDataReader> ReaderExecutedAsync(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result,
        CancellationToken cancellationToken = default)
        {
            if (IsSelectCommand(command))
            {
                string key = GenerateCacheKey(command);

                List<Dictionary<string, object>> resultList = new List<Dictionary<string, object>>();

                if (result.HasRows)
                {
                    Console.WriteLine("Escribiendo la cache");
                    while (await result.ReadAsync(cancellationToken))
                    {
                        var row = new Dictionary<string, object>();

                        for (int i = 0; i < result.FieldCount; i++)
                        {
                            row.TryAdd(result.GetName(i), result.GetValue(i));


                        }
                        resultList.Add(row);

                    }

                    if (resultList.Any())
                    {
                        // Configurar opciones de expiración para la caché
                        var cacheEntryOptions = new MemoryCacheEntryOptions
                        {
                            SlidingExpiration = TimeSpan.FromMinutes(5) // Extiende la vida útil si se accede
                        };
                        _cache.Set(key, resultList, cacheEntryOptions);
                    }
                }

                await result.CloseAsync();

                DataTable table = new DataTable();

                if (resultList.Any())
                {
                    foreach (var pair in resultList.First())
                    {
                        table.Columns.Add(pair.Key, pair.Value is not null && pair.Value.GetType() != typeof(DBNull)
                            ? pair.Value.GetType() : typeof(object));
                    }

                    foreach (var row in resultList)
                    {
                        table.Rows.Add(row.Values.ToArray());
                    }


                }
                band = true;
                return table.CreateDataReader();
            }

            return result;

        }

    }
}
