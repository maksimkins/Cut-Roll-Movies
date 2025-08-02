namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IBulkDeleteAsync<TEntity, TResult>
{
    public Task<TResult> BulkDeleteAsync(IEnumerable<TEntity> listToDelete);
}
