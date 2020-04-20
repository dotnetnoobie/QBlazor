using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace QBlazor
{
    public class History : IHistory
    {
        private readonly IJSRuntime jsRuntime;

        public History(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;
        }

        public async Task Forward()
        {
            await jsRuntime.InvokeVoidAsync("eval", "history.forward()");
        }
        public async Task Back()
        {
            await jsRuntime.InvokeVoidAsync("eval", "history.back()");
        }
    }
}