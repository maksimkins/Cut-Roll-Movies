namespace Cut_Roll_Movies.Core.Keywords.Services;

using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Keywords.Dtos;
using Cut_Roll_Movies.Core.Keywords.Models;

public interface IKeywordService
{
    public Task<Guid> DeleteKeywordByIdAsync(Guid? id);
    public Task<Guid> CreateKeywordAsync(KeywordCreateDto? dto);
    public Task<PagedResult<Keyword>> SearchKeywordAsync(KeywordSearchDto? dto);
    public Task<PagedResult<Keyword>> GetAllKeywordsAsync(KeywordPaginationDto? dto);
    public Task<Keyword?> GetKeywordByIdAsync(Guid? id);
}

