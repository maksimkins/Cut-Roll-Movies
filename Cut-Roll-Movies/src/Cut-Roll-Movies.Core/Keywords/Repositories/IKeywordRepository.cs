namespace Cut_Roll_Movies.Core.Keywords.Repositories;

using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;
using Cut_Roll_Movies.Core.Keywords.Dtos;
using Cut_Roll_Movies.Core.Keywords.Models;

public interface IKeywordRepository : IDeleteByIdAsync<Guid, Guid?>, ICreateAsync<KeywordCreateDto, Guid>, ISearchAsync<IEnumerable<Keyword>, string>
{
    Task<IEnumerable<Keyword>> GetAllAsync();
    Task<Keyword?> GetByIdAsync(Guid id);
    Task<Keyword?> GetByNameAsync(string name);
    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
}
