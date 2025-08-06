using Cut_Roll_Movies.Core.Casts.Repositories;
using Cut_Roll_Movies.Core.Casts.Services;
using Cut_Roll_Movies.Core.Common.Services;
using Cut_Roll_Movies.Core.Countries.Repositories;
using Cut_Roll_Movies.Core.Countries.Services;
using Cut_Roll_Movies.Core.Crews.Repositories;
using Cut_Roll_Movies.Core.Crews.Services;
using Cut_Roll_Movies.Core.Genres.Repositories;
using Cut_Roll_Movies.Core.Genres.Services;
using Cut_Roll_Movies.Core.Keywords.Repositories;
using Cut_Roll_Movies.Core.Keywords.Services;
using Cut_Roll_Movies.Core.MovieGenres.Repositories;
using Cut_Roll_Movies.Core.MovieGenres.Services;
using Cut_Roll_Movies.Core.MovieImages.Repositories;
using Cut_Roll_Movies.Core.MovieImages.Service;
using Cut_Roll_Movies.Core.MovieKeywords.Repositories;
using Cut_Roll_Movies.Core.MovieKeywords.Service;
using Cut_Roll_Movies.Core.MovieOriginCountries.Repository;
using Cut_Roll_Movies.Core.MovieOriginCountries.Service;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Repositories;
using Cut_Roll_Movies.Core.MovieProductionCompanies.Service;
using Cut_Roll_Movies.Core.MovieProductionCountries.Repositories;
using Cut_Roll_Movies.Core.MovieProductionCountries.Service;
using Cut_Roll_Movies.Core.Movies.Repositories;
using Cut_Roll_Movies.Core.Movies.Service;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Repositories;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Service;
using Cut_Roll_Movies.Core.MovieVideos.Repositories;
using Cut_Roll_Movies.Core.MovieVideos.Service;
using Cut_Roll_Movies.Core.People.Repositories;
using Cut_Roll_Movies.Core.People.Service;
using Cut_Roll_Movies.Core.ProductionCompanies.Repositores;
using Cut_Roll_Movies.Core.ProductionCompanies.Service;
using Cut_Roll_Movies.Core.SpokenLanguages.Repositories;
using Cut_Roll_Movies.Core.SpokenLanguages.Service;
using Cut_Roll_Movies.Infrastructure.Cast.Repositories;
using Cut_Roll_Movies.Infrastructure.Cast.Services;
using Cut_Roll_Movies.Infrastructure.Common.Services;
using Cut_Roll_Movies.Infrastructure.Countries.Repositories;
using Cut_Roll_Movies.Infrastructure.Countries.Services;
using Cut_Roll_Movies.Infrastructure.Crew.Repositories;
using Cut_Roll_Movies.Infrastructure.Crew.Services;
using Cut_Roll_Movies.Infrastructure.Genres.Repositories;
using Cut_Roll_Movies.Infrastructure.Genres.Services;
using Cut_Roll_Movies.Infrastructure.Keywords.Repositories;
using Cut_Roll_Movies.Infrastructure.Keywords.Services;
using Cut_Roll_Movies.Infrastructure.MovieGenres.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieGenres.Services;
using Cut_Roll_Movies.Infrastructure.MovieImages.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieImages.Services;
using Cut_Roll_Movies.Infrastructure.MovieKeywords.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieKeywords.Services;
using Cut_Roll_Movies.Infrastructure.MovieOriginCountries.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieOriginCountries.Services;
using Cut_Roll_Movies.Infrastructure.MovieProductionCompanies.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieProductionCompanies.Services;
using Cut_Roll_Movies.Infrastructure.MovieProductionCountries.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieProductionCountries.Services;
using Cut_Roll_Movies.Infrastructure.Movies.Repositories;
using Cut_Roll_Movies.Infrastructure.Movies.Services;
using Cut_Roll_Movies.Infrastructure.MovieSpokenLanguages.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieSpokenLanguages.Services;
using Cut_Roll_Movies.Infrastructure.MovieVideos.Repositories;
using Cut_Roll_Movies.Infrastructure.MovieVideos.Services;
using Cut_Roll_Movies.Infrastructure.People.Repositories;
using Cut_Roll_Movies.Infrastructure.People.Services;
using Cut_Roll_Movies.Infrastructure.ProductionCountries.Repositories;
using Cut_Roll_Movies.Infrastructure.ProductionCountries.Services;
using Cut_Roll_Movies.Infrastructure.SpokenLanguages.Repositories;
using Cut_Roll_Movies.Infrastructure.SpokenLanguages.Services;

namespace Cut_Roll_Movies.Api.Common.Extensions.ServiceCollection;

public static class RegisterDependencyInjectionMethod
{
    public static void RegisterDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IMovieRepository, MovieEfCoreRepository>();
        serviceCollection.AddTransient<ICastRepository, CastEfCoreRepository>();
        serviceCollection.AddTransient<ICrewRepository, CrewEfCoreRepository>();
        serviceCollection.AddTransient<IGenreRepository, GenreEfCoreRepository>();
        serviceCollection.AddTransient<IKeywordRepository, KeywordEfCoreRepository>();
        serviceCollection.AddTransient<IPersonRepository, PersonEfCoreRepository>();
        serviceCollection.AddTransient<ISpokenLanguageRepository, SpokenLanguageEfCoreRepository>();
        serviceCollection.AddTransient<IProductionCompanyRepository, ProductionCompanyEfCoreRepository>();
        serviceCollection.AddTransient<ICountryRepository, CountryEfCoreRepository>();
        serviceCollection.AddTransient<IMovieGenreRepository, MovieGenreEfCoreRepository>();
        serviceCollection.AddTransient<IMovieImageRepository, MovieImageEfCoreRepository>();
        serviceCollection.AddTransient<IMovieVideoRepository, MovieVideoEfCoreRepository>();
        serviceCollection.AddTransient<IMovieKeywordRepository, MovieKeywordEfCoreRepository>();
        serviceCollection.AddTransient<IMovieOriginCountryRepository, MovieOriginCountryEfCoreRepository>();
        serviceCollection.AddTransient<IMovieProductionCompanyRepository, MovieProductionCompanyEfCoreRepository>();
        serviceCollection.AddTransient<IMovieProductionCountryRepository, MovieProductionCountryEfCoreRepository>();
        serviceCollection.AddTransient<IMovieSpokenLanguageRepository, MovieSpokenLanguageEfCoreRepository>();
        

        serviceCollection.AddTransient<IMovieService, MovieService>();
        serviceCollection.AddTransient<ICastService, CastService>();
        serviceCollection.AddTransient<ICrewService, CrewService>();
        serviceCollection.AddTransient<IGenreService, GenreService>();
        serviceCollection.AddTransient<IKeywordService, KeywordService>();
        serviceCollection.AddTransient<IPersonService, PersonService>();
        serviceCollection.AddTransient<ISpokenLanguageService, SpokenLanguageService>();
        serviceCollection.AddTransient<IProductionCompanyService, ProductionCompanyService>();
        serviceCollection.AddTransient<ICountryService, CountryService>();
        serviceCollection.AddTransient<IMovieGenreService, MovieGenreService>();
        serviceCollection.AddTransient<IMovieImageService, MovieImageService>();
        serviceCollection.AddTransient<IMovieVideoService, MovieVideoService>();
        serviceCollection.AddTransient<IMovieKeywordService, MovieKeywordService>();
        serviceCollection.AddTransient<IMovieOriginCountryService, MovieOriginCountryService>();
        serviceCollection.AddTransient<IMovieProductionCompanyService, MovieProductionCompanyService>();
        serviceCollection.AddTransient<IMovieProductionCountryService, MovieProductionCountryService>();
        serviceCollection.AddTransient<IMovieSpokenLanguageService, MovieSpokenLanguageService>();

        serviceCollection.AddTransient<IMessageBrokerService, RabbitMqService>();

        //serviceCollection.AddHostedService<UserRabbitMqService>(); // AddHostedServicesMethod
    } 
}