namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IGetByIdAsync<TId, TReturnEntity>
{
    Task<TReturnEntity> GetByIdAsync(TId id);
}
