using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Location : ILocation
    {
        private readonly IJSRuntime jsRuntime;

        public Location(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;
        }

        public async Task<string> Href()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "location.href");
        }

        public async Task<string> Hostname()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "location.hostname");
        }

        public async Task<string> Pathname()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "location.pathname");
        }

        public async Task<string> Protocol()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "location.protocol");
        }

        public async Task<string> Assign(string url)
        {
            return await jsRuntime.InvokeAsync<string>("eval", $"location.Assign({url})");
        }
    }
}
