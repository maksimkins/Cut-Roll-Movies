using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.Movies.Repositories;

public interface IMovieRepository : ISearchAsync<PagedResult<Movie>, MovieSearchRequest>, IGetByIdAsync<Movie?, int>, IUpdateAsync<MovieUpdateDto, int?>, IDeleteByIdAsync<int, int?>, ICreateAsync<MovieCreateDto, int>, ICountAsync
{
    
}