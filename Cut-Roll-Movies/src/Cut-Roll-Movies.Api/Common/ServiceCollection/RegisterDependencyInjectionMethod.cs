using Cut_Roll_Movies.Core.Common.Services;
using Cut_Roll_Movies.Infrastructure.Common.Services;

namespace Cut_Roll_Movies.Api.Common.Extensions.ServiceCollection;

public static class RegisterDependencyInjectionMethod
{
    public static void RegisterDependencyInjection(this IServiceCollection serviceCollection)
    {
        // serviceCollection.AddTransient<INewsArticleRepository, NewsArticleEfCoreRepository>();

        serviceCollection.AddTransient<IMessageBrokerService, RabbitMqService>();

        //serviceCollection.AddHostedService<UserRabbitMqService>(); // AddHostedServicesMethod
    } 
}