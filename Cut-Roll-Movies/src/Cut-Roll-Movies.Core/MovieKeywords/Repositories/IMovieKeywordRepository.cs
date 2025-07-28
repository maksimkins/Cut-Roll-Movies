namespace Cut_Roll_Movies.Core.MovieKeywords.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Keywords.Models;
using Cut_Roll_Movies.Core.MovieKeywords.Dtos;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieKeywordRepository : ICreateAsync<Guid, MovieKeywordDto>, IDeleteAsync<Guid, MovieKeywordDto>, IDeleteRangeById<bool, Guid>
{
    Task<IEnumerable<Keyword>> GetKeywordsByMovieIdAsync(Guid movieId);
    Task<IEnumerable<Movie>> GetMoviesByKeywordIdAsync(MovieSearchByKeywordDto searchDto);
}
