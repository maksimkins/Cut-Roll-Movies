namespace Cut_Roll_Movies.Core.Casts.Repositories;

using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface ICastRepository : IUpdateAsync<CastUpdateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>,
    ICreateAsync<CastCreateDto, Guid?>, ISearchAsync<CastSearchDto, PagedResult<Cast>>, IBulkCreateAsync<CastCreateDto, bool>,
    IBulkDeleteAsync<Guid, bool>, IDeleteRangeById<Guid, bool>
{
    public Task<PagedResult<Cast>> GetByMovieIdAsync(CastGetByMovieIdDto dto);
    public Task<PagedResult<Cast>> GetByPersonIdAsync(CastGetByPersonIdDto dto);
    public Task<bool> ExistsByIdAsync(Guid id);
}
