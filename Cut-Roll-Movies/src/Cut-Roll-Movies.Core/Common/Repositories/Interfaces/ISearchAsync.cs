namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface ISearchAsync<TResponse, TRequest>
{
    Task<TResponse> SearchAsync(TRequest request);
}

