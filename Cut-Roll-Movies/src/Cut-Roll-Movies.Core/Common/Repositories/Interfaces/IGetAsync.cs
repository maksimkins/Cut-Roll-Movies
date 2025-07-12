namespace Cut_Roll_Movies.Core.Common.Repositories.Interfaces;

public interface IGetAsync<TResponse, TRequest>
{
    Task<TResponse> GetAsync(TRequest request);
}

