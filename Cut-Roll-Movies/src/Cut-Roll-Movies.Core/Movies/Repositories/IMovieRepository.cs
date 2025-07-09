using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Movies.Dtos;
using Cut_Roll_Movies.Core.Movies.Models;

namespace Cut_Roll_Movies.Core.Movies.Repositories;

public interface IMovieRepository : IGetAsync<PagedResult<Movie>, MovieSearchRequest>, IGetByIdAsync<Movie?, int>, IUpdateAsync<Movie, int?>, IDeleteByIdAsync<int, int?>, ICreateAsync<Movie, int>, ICountAsync
{
    
}