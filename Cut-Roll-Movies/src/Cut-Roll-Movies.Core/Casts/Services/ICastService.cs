using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Common.Dtos;

namespace Cut_Roll_Movies.Core.Casts.Services;

public interface ICastService
{
    public Task<Guid> UpdateCastAsync(CastUpdateDto? dto);
    public Task<Guid> DeleteCastByIdAsync(Guid? id);
    public Task<Guid> CreateCastAsync(CastCreateDto? dto);
    public Task<PagedResult<Cast>> SearchCastAsync(CastSearchDto? request);
    public Task<PagedResult<Cast>> GetCastByMovieIdAsync(CastGetByMovieIdDto? dto);
    public Task<PagedResult<Cast>> GetCastByPersonIdAsync(CastGetByPersonIdDto? dto);
    public Task<bool> BulkCreateCasteAsync(IEnumerable<CastCreateDto>? toCreate);
    public Task<bool> BulkDeleteCastAsync(IEnumerable<Guid>? toDeleteIds);
    public Task<bool> DeleteCastRangeByMovieIdAsync(Guid? movieId);
}


    
