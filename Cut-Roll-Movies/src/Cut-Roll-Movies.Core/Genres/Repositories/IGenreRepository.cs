using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Genres.Dtos;

namespace Cut_Roll_Movies.Core.Genres.Repositories;

public interface IGenreRepository : IDeleteByIdAsync<int, int?>, ICreateAsync<GenreCreateDto, int>
{
    
}
