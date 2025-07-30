namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface ISearchAsync<TRequest, TResponse>
{
    Task<TResponse> SearchAsync(TRequest request);
}

