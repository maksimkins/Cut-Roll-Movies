namespace Cut_Roll_Movies.Core.Casts.Repositories;

using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface ICastRepository : IGetByIdAsync<Guid, Cast?>, IUpdateAsync<CastUpdateDto, Guid?>, IDeleteAsync<CastDeleteDto, Guid?>,
    ICreateAsync<CastCreateDto, Guid?>, ISearchAsync<CastSearchDto, IEnumerable<Cast>>, IBulkCreateAsync<CastCreateDto, bool>,
    IBulkDeleteAsync<CastCreateDto, bool>
{
    public Task<IEnumerable<Cast>> GetByMovieIdAsync(Guid movieId);
    public Task<bool> ExistsAsync(Guid id);
}
