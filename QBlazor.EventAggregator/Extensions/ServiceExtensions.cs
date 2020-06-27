using System;
using QBlazor;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds IEventAggregator as a singleton
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddEventAggregator(this IServiceCollection services, Action<EventAggregatorOptions> configure = null)
        {
          //  services.AddSingleton<IEventAggregator, EventAggregator>();

            if (!services.Contains(new ServiceDescriptor(typeof(IEventAggregator), typeof(EventAggregator))))
            {
                services.AddScoped<IEventAggregator, EventAggregator>();
            }

            if (configure != null)
            {
                services.Configure(configure);
            }
            
            return services;
        }
    }
}