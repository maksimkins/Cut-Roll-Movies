namespace Cut_Roll_Movies.Api.Common.ServiceCollection;

using Cut_Roll_Movies.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

public static class InitDbContextMethod
{
    public static void InitDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlConnection")
            ?? throw new SystemException("connectionString is not set");

        serviceCollection.AddDbContext<MovieDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}