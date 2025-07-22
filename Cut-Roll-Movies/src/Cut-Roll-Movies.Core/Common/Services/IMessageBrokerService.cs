namespace Cut_Roll_Movies.Core.Common.Services;

public interface IMessageBrokerService
{
    public Task PushAsync<T>(string destination, T obj);
}