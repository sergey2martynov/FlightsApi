using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class DatabaseStartupHelpers
    {
        public static async Task<WebApplication> SetupDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                var initialiser = scope.ServiceProvider.GetRequiredService<DataInitializer>();

                try
                {
                    var arePendingMigrations = context.Database.GetPendingMigrations().Any();
                    await context.Database.MigrateAsync();

                    if (arePendingMigrations)
                    {
                        await initialiser.SeedAsync();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while creating/migrating or seeding the database.");

                    throw;
                }
            }

            return app;
        }
    }
}
