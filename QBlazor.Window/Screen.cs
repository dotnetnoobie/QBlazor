using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Screen : IScreen
    {
        private readonly IJSRuntime jsRuntime;

        public Screen(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;
        }

        public async Task<int> Width()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "screen.width");
        }

        public async Task<int> Height()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "screen.height");
        }

        public async Task<int> AvailWidth()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "screen.availWidth");
        }

        public async Task<int> AvailHeight()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "screen.availHeight");
        }

        public async Task<int> ColorDepth()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "screen.colorDepth");
        }

        public async Task<int> PixelDepth()
        {
            return await jsRuntime.InvokeAsync<int>("eval", "screen.pixelDepth");
        }
    }
}