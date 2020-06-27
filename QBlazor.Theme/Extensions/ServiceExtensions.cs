using Microsoft.Extensions.DependencyInjection;

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddTheming(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(ILocalStorage), typeof(LocalStorage))))
            {
                services.AddScoped<ILocalStorage, LocalStorage>();
            }

            if (!services.Contains(new ServiceDescriptor(typeof(ITheme), typeof(Theme))))
            {
                services.AddScoped<ITheme, Theme>();
            }

            return services; 
        }
    }
}