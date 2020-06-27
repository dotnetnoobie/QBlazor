using Microsoft.Extensions.DependencyInjection;

namespace QBlazor
{ 
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(INotifications), typeof(Notifications))))
            {
                services.AddScoped<INotifications, Notifications>();
            }

            return services;
        }
    }
}