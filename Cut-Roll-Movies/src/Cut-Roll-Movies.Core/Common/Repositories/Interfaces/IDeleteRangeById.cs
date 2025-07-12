namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IDeleteRangeById<TReturn, TId>
{
    Task<TReturn> DeleteRangeById(TId id);
}
