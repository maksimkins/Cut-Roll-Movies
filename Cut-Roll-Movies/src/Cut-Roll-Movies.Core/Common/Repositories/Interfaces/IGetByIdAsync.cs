namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IGetByIdAsync<TEntity, TId>
{
    Task<TEntity?> GetByIdAsync(TId id);
}
