using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;

namespace Cut_Roll_Movies.Core.Casts.Services;

public interface ICastService
{
    public Task<Cast?> GetCastByIdAsync(Guid? id);
    public Task<Guid> UpdateCastAsync(CastUpdateDto? dto);
    public Task<Guid> DeleteCastAsync(CastDeleteDto? dto);
    public Task<Guid> CreateCastAsync(CastCreateDto? dto);
    public Task<IEnumerable<Cast>> SearchCastAsync(CastSearchDto? request);
    public Task<IEnumerable<Cast>> GetCastByMovieIdAsync(Guid? movieId);
    public Task<bool> BulkCreatCasteAsync(IEnumerable<CastCreateDto> toCreate);
    public Task<bool> BulkCreateCastAsync(IEnumerable<CastDeleteDto> toDelete);
}


    
