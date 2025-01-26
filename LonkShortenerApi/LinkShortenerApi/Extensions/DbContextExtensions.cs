using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerApi.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task MigrateDatabaseAsync<TContext>(this IHost webApp) where TContext : DbContext
        {
            await using var scope = webApp.Services.CreateAsyncScope();
            await using var appContext = scope.ServiceProvider.GetRequiredService<TContext>();
            var config = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            // var pendingMigrations = (await appContext.Database.GetPendingMigrationsAsync()).ToList();
            // logger.LogInformation("Pending Migrations ({Count}):\n{Data}", pendingMigrations.Count,
            //     string.Join("\n", pendingMigrations));
            //
            await appContext.Database.MigrateAsync();
            // var appliedMigrations = (await appContext.Database.GetAppliedMigrationsAsync()).ToList();
            // logger.LogInformation("Applied Migrations ({Count}):\n{Data}", appliedMigrations.Count,
            //     string.Join("\n", appliedMigrations));
        }
    }
}
