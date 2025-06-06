using System.Runtime.CompilerServices;
using CoffeeShopApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Migrations
{
    public class MigrationsExtensions
    {
        public static void ApplyMigrations(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<CoffeeShopContext>();

            dbContext.Database.Migrate();
        }
    }
}
