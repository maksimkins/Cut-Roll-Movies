namespace Cut_Roll_Movies.Core.Genres.Services;

using Cut_Roll_Movies.Core.Genres.Dtos;
using Cut_Roll_Movies.Core.Genres.Models;

public interface IGenreService
{
    public Task<Guid> DeleteGenreByIdAsync(Guid id);
    public Task<Guid> CreateGenreAsync(GenreCreateDto dto);
    public Task<Genre?> GetGenreByIdAsync(Guid id);
    public Task<IEnumerable<Genre>> GetAllGenresAsync();
    public Task<Genre?> GetGenreByNameAsync(string name);
}


