namespace Cut_Roll_Movies.Infrastructure.Cast.Repositories;

using Cut_Roll_Movies.Core.Casts.Dtos;
using Cut_Roll_Movies.Core.Casts.Models;
using Cut_Roll_Movies.Core.Casts.Repositories;
using Cut_Roll_Movies.Infrastructure.Common.Data;

public class CastEfCoreRepository : ICastRepository
{
    private readonly MovieDbContext _dbContext;
    public CastEfCoreRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> BulkCreateAsync(IEnumerable<CastCreateDto> listToCreate)
    {
        var newCast = listToCreate.Select(toCreate => new Cast
        {
            MovieId = toCreate.MovieId,
            PersonId = toCreate.PersonId,
            Character = toCreate.Character,
            CastOrder = toCreate.CastOrder,
        });
        _dbContext.Cast.AddRangeAsync(newCast);
    }

    public Task<bool> BulkDeleteAsync(IEnumerable<CastCreateDto> listToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> CreateAsync(CastCreateDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> DeleteByIdAsync(CastDeleteDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Core.Casts.Models.Cast?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Core.Casts.Models.Cast>> GetByMovieIdAsync(Guid movieId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Core.Casts.Models.Cast>> SearchAsync(CastSearchDto request)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> UpdateAsync(CastUpdateDto entity)
    {
        throw new NotImplementedException();
    }
}
