using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieImages.Dtos;

namespace Cut_Roll_Movies.Core.MovieImages.Repositories;

public interface IMovieImageRepository : ICreateAsync<int, MovieImageCreateDto>, IDeleteAsync<int, int>, IDeleteRangeById<bool, int>
{

}
