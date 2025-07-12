namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IDeleteAsync<TReturn, TEntity>
{
    Task<TReturn> DeleteByIdAsync(TEntity entity);
}
