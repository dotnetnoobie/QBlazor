using Microsoft.Extensions.DependencyInjection; 

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNavigator(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(INavigator), typeof(Navigator))))
            {
                services.AddScoped<INavigator, Navigator>();
            }

            return services;
        } 
    }
}