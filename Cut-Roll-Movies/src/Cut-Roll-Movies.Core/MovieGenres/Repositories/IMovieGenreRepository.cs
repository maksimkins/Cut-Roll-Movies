using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieGenres.Models;

namespace Cut_Roll_Movies.Core.MovieGenres.Repositories;

public interface IMovieGenreRepository : ICreateAsync<int, MovieGenre>, IDeleteAsync<int, MovieGenre>, IDeleteRangeById<bool, int>
{
    
}
