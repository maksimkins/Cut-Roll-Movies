using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Countries.Models;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.Genres.Models;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.MovieGenres.Models;
using Cut_Roll_Movies.Core.MovieImages.Models;
using Cut_Roll_Movies.Core.MovieKeywords.Models;
using Cut_Roll_Movies.Core.MovieOriginCountries.Models;
using Cut_Roll_Movies.Core.MovieProductionCompanies;
using Cut_Roll_Movies.Core.MovieProductionCountries.Models;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Models;
using Cut_Roll_Movies.Core.MovieVideos.Models;
using Cut_Roll_Movies.Core.People.Models;
using Cut_Roll_Movies.Core.ProductionCompanies.Models;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;
using Microsoft.EntityFrameworkCore;

namespace Cut_Roll_Movies.Infrastructure.Common.Data;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
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
        
        // ===== Movies =====
        modelBuilder.Entity<Movie>()
            .ToTable("movies")
            .HasKey(m => m.Id);

        // ===== Genres =====
        modelBuilder.Entity<Genre>()
            .ToTable("genres")
            .HasKey(g => g.Id);

        modelBuilder.Entity<MovieGenre>()
            .ToTable("movie_genres")
            .HasKey(mg => new { mg.GenreId, mg.MovieId });

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        // ===== People =====
        modelBuilder.Entity<Person>()
            .ToTable("people")
            .HasKey(p => p.Id);

        // ===== Cast =====
        modelBuilder.Entity<Cast>()
            .ToTable("cast")
            .HasKey(c => c.Id);

        modelBuilder.Entity<Cast>()
            .HasOne(c => c.Movie)
            .WithMany(m => m.Cast)
            .HasForeignKey(c => c.MovieId);

        modelBuilder.Entity<Cast>()
            .HasOne(c => c.Person)
            .WithMany(p => p.CastRoles)
            .HasForeignKey(c => c.PersonId);

        // ===== Crew =====
        modelBuilder.Entity<Crew>()
            .ToTable("crew")
            .HasKey(c => c.Id);

        modelBuilder.Entity<Crew>()
            .HasOne(c => c.Movie)
            .WithMany(m => m.Crew)
            .HasForeignKey(c => c.MovieId);

        modelBuilder.Entity<Crew>()
            .HasOne(c => c.Person)
            .WithMany(p => p.CrewRoles)
            .HasForeignKey(c => c.PersonId);

        // ===== Production Companies =====
        modelBuilder.Entity<ProductionCompany>()
            .ToTable("production_companies")
            .HasKey(c => c.Id);

        modelBuilder.Entity<ProductionCompany>()
            .HasOne(c => c.Country)
            .WithMany(cn => cn.Companies)
            .HasForeignKey(c => c.CountryCode)
            .IsRequired(false);

        // ===== MovieProductionCompanies =====
        modelBuilder.Entity<MovieProductionCompany>()
            .ToTable("movie_production_companies")
            .HasKey(mpc => new { mpc.MovieId, mpc.CompanyId });

        modelBuilder.Entity<MovieProductionCompany>()
            .HasOne(mpc => mpc.Movie)
            .WithMany(m => m.ProductionCompanies)
            .HasForeignKey(mpc => mpc.MovieId);

        modelBuilder.Entity<MovieProductionCompany>()
            .HasOne(mpc => mpc.Company)
            .WithMany(pc => pc.MovieProductionCompanies)
            .HasForeignKey(mpc => mpc.CompanyId);

        // ===== Countries =====
        modelBuilder.Entity<Country>()
            .ToTable("countries")
            .HasKey(c => c.Iso3166_1);

        // ===== MovieProductionCountries =====
        modelBuilder.Entity<MovieProductionCountry>()
            .ToTable("movie_production_countries")
            .HasKey(mpc => new { mpc.MovieId, mpc.CountryCode });

        modelBuilder.Entity<MovieProductionCountry>()
            .HasOne(mpc => mpc.Movie)
            .WithMany(m => m.ProductionCountries)
            .HasForeignKey(mpc => mpc.MovieId);

        modelBuilder.Entity<MovieProductionCountry>()
            .HasOne(mpc => mpc.Country)
            .WithMany()
            .HasForeignKey(mpc => mpc.CountryCode);

        // ===== Spoken Languages =====
        modelBuilder.Entity<SpokenLanguage>()
            .ToTable("spoken_languages")
            .HasKey(l => l.Iso639_1);

        modelBuilder.Entity<MovieSpokenLanguage>()
            .ToTable("movie_spoken_languages")
            .HasKey(msl => new { msl.MovieId, msl.LanguageCode });

        modelBuilder.Entity<MovieSpokenLanguage>()
            .HasOne(msl => msl.Movie)
            .WithMany(m => m.SpokenLanguages)
            .HasForeignKey(msl => msl.MovieId);

        modelBuilder.Entity<MovieSpokenLanguage>()
            .HasOne(msl => msl.Language)
            .WithMany(l => l.MovieSpokenLanguages)
            .HasForeignKey(msl => msl.LanguageCode);

        // ===== Videos =====
        modelBuilder.Entity<MovieVideo>()
            .ToTable("movie_videos")
            .HasKey(v => v.Id);

        modelBuilder.Entity<MovieVideo>()
            .HasOne(v => v.Movie)
            .WithMany(m => m.Videos)
            .HasForeignKey(v => v.MovieId);

        // ===== Keywords =====
        modelBuilder.Entity<Keyword>()
            .ToTable("keywords")
            .HasKey(k => k.Id);

        modelBuilder.Entity<MovieKeyword>()
            .ToTable("movie_keywords")
            .HasKey(mk => new { mk.MovieId, mk.KeywordId });

        modelBuilder.Entity<MovieKeyword>()
            .HasOne(mk => mk.Movie)
            .WithMany(m => m.Keywords)
            .HasForeignKey(mk => mk.MovieId);

        modelBuilder.Entity<MovieKeyword>()
            .HasOne(mk => mk.Keyword)
            .WithMany(k => k.MovieKeywords)
            .HasForeignKey(mk => mk.KeywordId);

        // ===== Movie Origin Countries =====
        modelBuilder.Entity<MovieOriginCountry>()
            .ToTable("movie_origin_countries")
            .HasKey(moc => new { moc.MovieId, moc.CountryCode });

        modelBuilder.Entity<MovieOriginCountry>()
            .HasOne(moc => moc.Movie)
            .WithMany(m => m.OriginCountries)
            .HasForeignKey(moc => moc.MovieId);

        modelBuilder.Entity<MovieOriginCountry>()
            .HasOne(moc => moc.Country)
            .WithMany()
            .HasForeignKey(moc => moc.CountryCode);

        // ===== Images =====
        modelBuilder.Entity<MovieImage>()
            .ToTable("movie_images")
            .HasKey(i => i.Id);

        modelBuilder.Entity<MovieImage>()
            .HasOne(i => i.Movie)
            .WithMany(m => m.Images)
            .HasForeignKey(i => i.MovieId);
    }   
}
