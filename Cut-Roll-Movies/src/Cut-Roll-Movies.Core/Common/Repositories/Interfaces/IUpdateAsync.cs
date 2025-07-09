namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IUpdateAsync<TEntity, TReturn>
{
    Task<TReturn> UpdateAsync(TEntity entity);
}
