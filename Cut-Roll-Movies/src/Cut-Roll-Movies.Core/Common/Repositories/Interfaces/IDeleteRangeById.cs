namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IDeleteRangeById<TId, TReturn>
{
    Task<TReturn> DeleteRangeById(TId id);
}
