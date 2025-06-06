using Npgsql;

namespace CoffeeShopApi.Utils
{
    public class ConnectionStringParser
    {
        public static string ParseConnectionString(string databaseUrl)
        {
            if (string.IsNullOrEmpty(databaseUrl))
            {
                throw new ArgumentNullException(nameof(databaseUrl));
            }

            // Parsear la URL de Render
            var uri = new Uri(databaseUrl);
            var userInfo = uri.UserInfo.Split(':');

            // Construir connection string compatible con Npgsql
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = uri.Host,
                Port = uri.Port,
                Username = userInfo[0],
                Password = userInfo.Length > 1 ? userInfo[1] : null,
                Database = uri.AbsolutePath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }
    }
}
