namespace Cut_Roll_Movies.Api.Common.WebApplication;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Cut_Roll_Movies.Infrastructure.Common.Data;

public static class UpdateDbMethod
{
    public static void UpdateDb(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<MovieDbContext>();

            dbContext.Database.Migrate();
        }
    }
}