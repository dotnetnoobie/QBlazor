using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Window : IWindow
    {
        public IHistory History { get; }

        public INavigator Navigator { get; }

        public ICookie Cookie { get; }

        public ILocation Location { get; }

        public IScreen Screen { get; }


        private readonly IJSRuntime jsRuntime;

        public Window(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;

            this.History = new History(this.jsRuntime);
            this.Navigator = new Navigator(this.jsRuntime);
            this.Cookie = new Cookie(this.jsRuntime);
            this.Location = new Location(this.jsRuntime);
            this.Screen = new Screen(this.jsRuntime);
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

        public async Task close()
        {
            await jsRuntime.InvokeVoidAsync("close");
        }



        public async Task<int> InnerHeight()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "innerHeight");
        }

        public async Task<int> InnerWidth()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "innerWidth");
        }
    }
}