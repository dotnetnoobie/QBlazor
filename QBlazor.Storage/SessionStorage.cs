using Microsoft.JSInterop;

namespace QBlazor
{
    public class SessionStorage : Storage, ISessionStorage
    {
        public SessionStorage(IJSRuntime jsRuntime) : base(jsRuntime)
        {
            this.type = "session";
        }
    }
}