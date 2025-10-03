using Polly;

namespace myRiderSharing.RiderApi.Extensions;

public static class MigrateDbContext
{
    public static void InitDbContextMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<RiderDbContext>();
            var logger = services.GetRequiredService<ILogger<RiderDbContext>>();
            try
            {
                context!.Database.EnsureCreated();

                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(RiderDbContext).Name);

                var retry = Policy.Handle<SqliteException>()
                    .WaitAndRetry(new TimeSpan[]
                    {
                        TimeSpan.FromSeconds(3),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(8)
                    });

                retry.Execute(() =>
                {
                    if (!context!.Riders.Any())
                    {
                        context.Riders.AddRange(
                            new List<Rider>()
                            {
                                new() { UserId = 1, FullName = "Rider 1", Email = "rider1@sharing.com", PhoneNumber = "2563152", Rating = 4, CreatedAt = DateTimeOffset.Now },
                                new() { UserId = 2, FullName = "Rider 2", Email = "rider2@sharing.com", PhoneNumber = "2563152", Rating = 5, CreatedAt = DateTimeOffset.Now },
                                new() { UserId = 3, FullName = "Rider 3", Email = "rider3@sharing.com", PhoneNumber = "2563152", Rating = 3.5m, CreatedAt = DateTimeOffset.Now },
                            }
                        );
                        context.SaveChanges();
                    }
                });
                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(RiderDbContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(RiderDbContext).Name);
                throw;
            }
        }
    }
}