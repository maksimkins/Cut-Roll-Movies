namespace Cut_Roll_Movies.Core.MovieKeywords.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.MovieKeywords.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieKeywordRepository : ICreateAsync<MovieKeywordDto, Guid?>, IDeleteAsync<MovieKeywordDto, Guid?>, IDeleteRangeById<Guid, bool>, 
IBulkCreateAsync<MovieKeywordDto, bool>, IBulkDeleteAsync<MovieKeywordDto, bool>
{
    Task<IEnumerable<Keyword>> GetKeywordsByMovieIdAsync(Guid movieId);
    Task<IEnumerable<Movie>> GetMoviesByKeywordIdAsync(MovieSearchByKeywordDto searchDto);
    Task<bool> ExistsAsync(MovieKeywordDto dto);
}
