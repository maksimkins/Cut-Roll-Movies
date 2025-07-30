namespace Cut_Roll_Movies.Core.Genres.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Genres.Dtos;
using Cut_Roll_Movies.Core.Genres.Models;

public interface IGenreRepository : IDeleteByIdAsync<Guid, Guid?>, ICreateAsync<GenreCreateDto, Guid?>, IGetByIdAsync<Guid, Genre?>
{
    public Task<IEnumerable<Genre>> GetAllAsync();
    public Task<Genre?> GetByNameAsync(string name);
    public Task<bool> ExistsAsync(Guid id);
    public Task<bool> ExistsByNameAsync(string name);
}
