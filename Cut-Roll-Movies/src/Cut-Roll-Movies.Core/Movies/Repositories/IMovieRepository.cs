namespace Cut_Roll_Movies.Core.Movies.Repositories;

using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Crews.Models;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

public interface IMovieRepository : ISearchAsync<MovieSearchRequest, PagedResult<Movie>>, IGetByIdAsync<Guid, Movie?>,
IUpdateAsync<MovieUpdateDto, Guid?>, IDeleteByIdAsync<Guid?, Guid>, ICreateAsync<MovieCreateDto, Guid?>, ICountAsync
{
    Task<IEnumerable<Cast>> GetCastByMovieIdAsync(Guid movieId);
    Task<IEnumerable<Crew>> GetCrewByMovieIdAsync(Guid movieId);
}