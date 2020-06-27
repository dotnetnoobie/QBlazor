using Microsoft.Extensions.DependencyInjection; 

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddLocalStorage(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(ILocalStorage), typeof(LocalStorage))))
            {
                services.AddScoped<ILocalStorage, LocalStorage>();
            }

            return services;
        }

        public static IServiceCollection AddSessionStorage(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(ISessionStorage), typeof(SessionStorage))))
            {
                services.AddScoped<ISessionStorage, SessionStorage>();
            }

            return services;
        }

        public static IServiceCollection AddLocalAndSessionStorage(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(ILocalStorage), typeof(LocalStorage))))
            {
                services.AddScoped<ILocalStorage, LocalStorage>();
            }

            if (!services.Contains(new ServiceDescriptor(typeof(ISessionStorage), typeof(SessionStorage))))
            {
                services.AddScoped<ISessionStorage, SessionStorage>();
            }

            return services;
        }
    }
}