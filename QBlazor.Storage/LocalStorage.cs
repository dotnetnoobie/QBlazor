using Microsoft.JSInterop;

namespace QBlazor
{
    public class LocalStorage : Storage, ILocalStorage
    {
        public LocalStorage(IJSRuntime jsRuntime) : base(jsRuntime)
        {
            // Local Storage
            this.type = "local";
        }
    }
}
