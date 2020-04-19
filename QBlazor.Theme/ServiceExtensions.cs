using Microsoft.Extensions.DependencyInjection;

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddTheming(this IServiceCollection services)
        {
            //if (!services.Contains(new ServiceDescriptor(typeof(ILocalStorage), typeof(LocalStorage))))
            //{
            //    services.AddScoped<ILocalStorage, LocalStorage>();
            //}

            services.AddScoped<ILocalStorage, LocalStorage>();

            services.AddScoped<Theme>();

            return services;
        }
    }
}