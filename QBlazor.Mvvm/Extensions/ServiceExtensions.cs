using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection; 
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QBlazor
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMvvm(this IServiceCollection services)
        {
            services.AddLocalStorage();

            var assembly = Assembly.GetCallingAssembly();
            var vms = assembly.GetTypes().Where(t => t.BaseType == typeof(ViewModelBase));

            foreach (var vm in vms)
            {
                services.AddScoped(vm);
            }

            return services;
        }

        public static WebAssemblyHost InitializeMvvm(this WebAssemblyHost host)
        {
            var assembly = Assembly.GetCallingAssembly();
            var vms = assembly.GetTypes().Where(t => t.BaseType == typeof(ViewModelBase));

            foreach (var vm in vms)
            {
                var viewmodel = host.Services.GetService(vm) as ViewModelBase;
                Task.Run(async () => await viewmodel.Initialize());
            }

            return host;
        }
    }
}