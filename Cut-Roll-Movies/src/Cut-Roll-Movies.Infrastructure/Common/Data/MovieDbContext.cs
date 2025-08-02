namespace Cut_Roll_Movies.Infrastructure.Common.Data;

using Cut_Roll_Movies.Core.Casts.Configuration;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Models;
using Cut_Roll_Movies.Core.Countries.Configurations;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.Crews.Configurations;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.Genres.Configurations;
using Cut_Roll_Movies.Core.Genres.Models;
using Cut_Roll_Movies.Core.Keywords.Configurations;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.MovieGenres.Configurations;
using Cut_Roll_Movies.Core.MovieGenres.Models;
using Cut_Roll_Movies.Core.MovieImages.Configurations;
using Cut_Roll_Movies.Core.MovieImages.Models;
using Cut_Roll_Movies.Core.MovieKeywords.Configurations;
using Cut_Roll_Movies.Core.MovieKeywords.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Configurations;
using Cut_Roll_Movies.Core.MovieOriginCountries.Models;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Configurations;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Models;
using Cut_Roll_Movies.Core.MovieProductionCountries.Models;
using Cut_Roll_Movies.Core.Movies.Configurations;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Configurations;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;
using Cut_Roll_Movies.Core.MovieVideos.Configurations;
using Cut_Roll_Movies.Core.MovieVideos.Models;
using Cut_Roll_Movies.Core.People.Configurations;
using Cut_Roll_Movies.Core.People.Models;
using Cut_Roll_Movies.Core.ProductionCompanies.Configurations;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;
using Cut_Roll_Movies.Core.SpokenLanguages.Configurations;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;
using Microsoft.EntityFrameworkCore;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<ExecutedScript> ExecutedScripts { get; set; } = default!;
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Cast> Cast { get; set; }
    public DbSet<Crew> Crew { get; set; }
    public DbSet<ProductionCompany> ProductionCompanies { get; set; }
    public DbSet<MovieProductionCompany> MovieProductionCompanies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<MovieProductionCountry> MovieProductionCountries { get; set; }
    public DbSet<SpokenLanguage> SpokenLanguages { get; set; }
    public DbSet<MovieSpokenLanguage> MovieSpokenLanguages { get; set; }
    public DbSet<MovieVideo> Videos { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<MovieKeyword> MovieKeywords { get; set; }
    public DbSet<MovieOriginCountry> MovieOriginCountries { get; set; }
    public DbSet<MovieImage> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExecutedScript>().HasKey(e => e.ScriptName);

        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new CastConfiguration());
        modelBuilder.ApplyConfiguration(new ProductionCompanyConfiguration());
        modelBuilder.ApplyConfiguration(new CrewConfiguration());
        modelBuilder.ApplyConfiguration(new MovieProductionCompanyConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new MovieProductionCountryConfiguration());
        modelBuilder.ApplyConfiguration(new SpokenLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new MovieSpokenLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new MovieVideoConfiguration());
        modelBuilder.ApplyConfiguration(new KeywordConfiguration());
        modelBuilder.ApplyConfiguration(new MovieKeywordConfiguration());
        modelBuilder.ApplyConfiguration(new MovieOriginCountryConfiguration());
        modelBuilder.ApplyConfiguration(new MovieImageConfiguration());
    }
}
