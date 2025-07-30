namespace Cut_Roll_Movies.Core.MovieSpokenLanguages.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Dtos;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;

public interface IMovieSpokenLanguageRepository : ICreateAsync<MovieSpokenLanguageDto, Guid?>, IDeleteAsync<MovieSpokenLanguageDto, Guid?>,
IDeleteRangeById<bool, Guid>, IBulkCreateAsync<MovieSpokenLanguageDto, bool>, IBulkDeleteAsync<MovieSpokenLanguageDto, bool>
{
    Task<IEnumerable<SpokenLanguage>> GetSpokenLanguagesByMovieIdAsync(Guid movieId);
    Task<bool> ExistsAsync(MovieSpokenLanguageDto dto);
    Task<IEnumerable<Movie>> GetMoviesBySpokenLanguageIdAsync(MovieSearchBySpokenLanguageDto movieSearchByCountryDto);
}
