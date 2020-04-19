using Microsoft.Extensions.DependencyInjection; 

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMetaData(this IServiceCollection services)
        {
            if (!services.Contains(new ServiceDescriptor(typeof(IMetaData), typeof(MetaData))))
            {
                services.AddScoped<IMetaData, MetaData>();
            }

            return services;
        } 
    }
}