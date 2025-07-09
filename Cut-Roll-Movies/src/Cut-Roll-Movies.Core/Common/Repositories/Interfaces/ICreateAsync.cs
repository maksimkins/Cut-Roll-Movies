namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface ICreateAsync<TEntity, TReturn>
{
    Task<TReturn> CreateAsync(TEntity entity);
}
