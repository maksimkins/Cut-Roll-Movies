namespace Cut_Roll_Movies.Api.Common.WebApplication;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Cut_Roll_Movies.Infrastructure.Common.Data;
using Cut_Roll_Movies.Core.Common.Models;

public static class UpdateDbContextMethod
{
    public static void UpdateDbContext(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<MovieDbContext>();
        var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("DBUpdate");

        dbContext.Database.Migrate();

        // dbContext.Database.ExecuteSqlRaw(
        //     @"CREATE TABLE IF NOT EXISTS ""ExecutedScripts"" (
        //         ""ScriptName"" TEXT PRIMARY KEY,
        //         ""ExecutedAt"" TIMESTAMP DEFAULT now()
        //     );"
        // );

        var sqlFolder = Path.Combine(AppContext.BaseDirectory, "SqlScripts");
        if (!Directory.Exists(sqlFolder))
        {
            Console.Write("SqlScripts directory not found: " + sqlFolder);

            logger.LogWarning("SqlScripts directory not found: " + sqlFolder);
            return;
        }

        var sqlFiles = Directory.GetFiles(sqlFolder, "*.sql").OrderBy(f => f);
        foreach (var file in sqlFiles)
        {
            var scriptName = Path.GetFileName(file);
            var wasExecuted = dbContext.ExecutedScripts.Any(s => s.ScriptName == scriptName);

            if (wasExecuted)
            {
                Console.Write($"Skipped already executed script: {scriptName}");

                logger.LogInformation($"Skipped already executed script: {scriptName}");
                continue;
            }

            var scriptText = File.ReadAllText(file);
            try
            {
                dbContext.Database.ExecuteSqlRaw(scriptText);
                dbContext.ExecutedScripts.Add(new ExecutedScript
                {
                    ScriptName = scriptName,
                    ExecutedAt = DateTime.UtcNow
                });
                dbContext.SaveChanges();

                Console.Write($"Successfully executed script: {scriptName}");

                logger.LogInformation($"Successfully executed script: {scriptName}");
            }
            catch (Exception ex)
            {
                Console.Write($"\n\n\n\n\n\n\nFailed to execute script: {scriptName}\n\n\n\n\n\n");

                logger.LogError(ex, $"\n\n\n\n\n\n\nFailed to execute script: {scriptName}\n\n\n\n\n\n");
                throw;
            }
        }
    }
}
