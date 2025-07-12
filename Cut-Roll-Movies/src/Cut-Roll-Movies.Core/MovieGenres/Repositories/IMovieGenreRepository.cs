using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieGenres.Dtos;

namespace Cut_Roll_Movies.Core.MovieGenres.Repositories;

public interface IMovieGenreRepository : ICreateAsync<int, MovieGenreDto>, IDeleteAsync<int, MovieGenreDto>, IDeleteRangeById<bool, int>
{
    
}
