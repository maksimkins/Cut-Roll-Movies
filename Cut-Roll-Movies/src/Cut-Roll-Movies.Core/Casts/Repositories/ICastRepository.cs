namespace Cut_Roll_Movies.Core.Casts.Repositories;

using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Dtos;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface ICastRepository : IGetByIdAsync<Cast?, Guid>, IUpdateAsync<CastUpdateDto, Guid?>, IDeleteByIdAsync<Guid, Guid?>,
    ICreateAsync<CastUpdateDto, Guid>, ISearchAsync<IEnumerable<Cast>, CastSearchDto>
{
    public Task<IEnumerable<Cast>> GetByMovieIdAsync(Guid movieId);
    Task<PagedResult<Cast>> GetPagedAsync(int page, int pageSize, string? search);
}
