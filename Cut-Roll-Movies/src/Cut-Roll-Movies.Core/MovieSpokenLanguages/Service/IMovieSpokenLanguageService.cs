namespace Cut_Roll_Movies.Core.MovieSpokenLanguages.Service;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;
using Cut_Roll_Movies.Core.MovieSpokenLanguages.Dtos;
using Cut_Roll_Movies.Core.SpokenLanguages.Models;

public interface IMovieSpokenLanguageService
{
    Task<Guid> CreateMovieSpokenLanguageAsync(MovieSpokenLanguageDto? dto);
    Task<Guid> DeleteMovieSpokenLanguageAsync(MovieSpokenLanguageDto? dto);
    Task<Guid> DeleteMovieSpokenLanguageRangeByMovieId(Guid? movieId);
    Task<IEnumerable<SpokenLanguage>> GetSpokenLanguagesByMovieIdAsync(Guid? movieId);
    Task<PagedResult<Movie>> GetMoviesBySpokenLanguageIdAsync(MovieSearchBySpokenLanguageDto? movieSearchByCountryDto);
    Task<bool> BulkCreateMovieSpokenLaguageAsync(IEnumerable<MovieSpokenLanguageDto?>? toCreate);
    Task<bool> BulkDeleteeMovieSpokenLaguageAsync(IEnumerable<MovieSpokenLanguageDto?>? toDelete);
}

