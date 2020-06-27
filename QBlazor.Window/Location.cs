using Microsoft.JSInterop;
using System;
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

        public async Task Assign(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            { 
                await jsRuntime.InvokeVoidAsync("eval", $"location.Assign({url})");
            }
        }
    }
}
