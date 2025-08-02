namespace Cut_Roll_Movies.Core.Keywords.Services;

using Cut_Roll_Movies.Core.Keywords.Dtos;
using Cut_Roll_Movies.Core.Keywords.Models;

public interface IKeywordService
{
    public Task<Guid> DeleteKeywordByIdAsync(Guid? id);
    public Task<Guid> CreateKeywordAsync(KeywordCreateDto? dto);
    public Task<IEnumerable<Keyword>> SearchKeywordAsync(KeywordSearchDto? dto);
    public Task<IEnumerable<Keyword>> GetAllKeywordsAsync();
    public Task<Keyword?> GetKeywordByIdAsync(Guid? id);
    public Task<Keyword?> GetKeywordByNameAsync(string? name);
    public Task<bool> ExistsAsync(Guid? id);
    public Task<bool> ExistsByNameAsync(string? name);
}

