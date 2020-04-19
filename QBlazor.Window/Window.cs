using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Window : IWindow
    {
        private readonly IJSRuntime jsRuntime;

        public Window(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;
        }

        public async Task Alert(string message)
        {
            await jsRuntime.InvokeVoidAsync("alert", message);
        }

        public async Task Open(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                await jsRuntime.InvokeVoidAsync("open", url);
            }
        }
    }
}