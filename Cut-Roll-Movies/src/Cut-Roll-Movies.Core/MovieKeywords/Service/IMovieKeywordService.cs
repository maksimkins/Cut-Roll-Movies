namespace Cut_Roll_Movies.Core.MovieKeywords.Service;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.MovieKeywords.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieKeywordService
{
    Task<Guid> CreateMovieKeywordAsync(MovieKeywordDto? dto);
    Task<Guid> DeleteMovieKeywordAsync(MovieKeywordDto? dto);
    Task<bool> DeleteMovieKeywordRangeByMovieId(Guid? movieId);
    Task<IEnumerable<Keyword>> GetKeywordsByMovieIdAsync(Guid? movieId);
    Task<PagedResult<Movie>> GetMoviesByKeywordIdAsync(MovieSearchByKeywordDto? searchDto);
    Task<bool> BulkCreateMovieKeywordAsync(IEnumerable<MovieKeywordDto>? toCreate);
    Task<bool> BulkDeleteMovieKeywordAsync(IEnumerable<MovieKeywordDto>? toDelete);
}


