using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Theme
    {
        public event EventHandler<bool> Changed;

        private async Task RaiseOnChanged()
        {
            await storage.Set(() => IsDark);
            Changed?.Invoke(this, IsDark);
        }

        private readonly IJSRuntime jsRuntime;
        private readonly ILocalStorage storage;

        private bool isDark;

        public bool IsDark
        {
            get => isDark;
            set
            {
                isDark = value;
                SetTheme();
            }
        }

        public Theme(IJSRuntime jsRuntime, ILocalStorage storage)
        {
            this.jsRuntime = jsRuntime;
            this.storage = storage;
        }

        public async Task Initialize() => IsDark = await storage.Get(() => IsDark);

        public void Toggle() => IsDark = !IsDark;

        public void SetTheme()
        {
            //Console.WriteLine("Set There: " + IsDark);

            var action = IsDark ? "setAttribute" : "removeAttribute";
            Task.Run(async () => await jsRuntime.InvokeVoidAsync($"document.body.{action}", "data-theme"));
            Task.Run(async () => await RaiseOnChanged());
        }
    }
}





//if (IsDark)
//{
//    Task.Run(async () => await js.InvokeVoidAsync("document.body.setAttribute", "data-theme", "dark"));
//}
//else
//{
//    Task.Run(async () => await js.InvokeVoidAsync("document.body.removeAttribute", "data-theme"));
//}


//_key = this.GetType().FullName + ".IsDark";

//Console.WriteLine("Key: " + _key);


// Task.Run(async () => IsDark = await localStorage.Get<bool>(_key)); 