namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IDeleteByIdAsync<TId, TReturn> 
{
    Task<TReturn> DeleteByIdAsync(TId id);
}
