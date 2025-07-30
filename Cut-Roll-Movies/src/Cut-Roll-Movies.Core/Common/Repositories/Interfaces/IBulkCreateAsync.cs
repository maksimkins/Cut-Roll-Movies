namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IBulkCreateAsync<TEntity, TResult>
{
    public Task<TResult> BulkCreateAsync(IEnumerable<TEntity> listToCreate);
}
