using Microsoft.Extensions.DependencyInjection; 

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddWindow(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(IWindow), typeof(Window))))
            {
                services.AddScoped<IWindow, Window>();
            }

            return services;
        } 
    }
}