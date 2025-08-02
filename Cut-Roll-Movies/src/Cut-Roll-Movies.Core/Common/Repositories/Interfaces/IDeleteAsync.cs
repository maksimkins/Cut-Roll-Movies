namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IDeleteAsync<TEntity, TReturn>
{
    Task<TReturn> DeleteAsync(TEntity entity);
}
