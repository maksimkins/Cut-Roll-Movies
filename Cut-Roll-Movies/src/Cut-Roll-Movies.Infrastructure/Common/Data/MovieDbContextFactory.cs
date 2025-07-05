using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cut_Roll_Movies.Infrastructure.Common.Data;

public class MovieDbContextFactory  : IDesignTimeDbContextFactory<MovieDbContext>
{
    public MovieDbContext CreateDbContext(string[] args)
    {
        // Get config from appsettings.Development.json or environment variables
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();

        var connectionString = config.GetConnectionString("DefaultConnection") 
            ?? config["POSTGRES_CONNECTION_STRING"];

        optionsBuilder.UseNpgsql(connectionString);

        return new MovieDbContext(optionsBuilder.Options);
    }
}