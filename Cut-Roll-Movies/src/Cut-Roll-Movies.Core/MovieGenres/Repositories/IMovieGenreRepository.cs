using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.MovieGenres.Dtos;

namespace Cut_Roll_Movies.Core.MovieGenres.Repositories;

public interface IMovieGenreRepository : ICreateAsync<Guid, MovieGenreDto>, IDeleteAsync<Guid, MovieGenreDto>, IDeleteRangeById<bool, Guid>
{
    
}
