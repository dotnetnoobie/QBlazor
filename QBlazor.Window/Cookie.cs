using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public class Cookie : ICookie
    {
        private readonly IJSRuntime jsRuntime;

        public Cookie(IJSRuntime jSRuntime)
        {
            this.jsRuntime = jSRuntime;
        }

        public async Task Set(string name, string value, int exdays)
        {
            var d = DateTimeOffset.UtcNow; 
            var expires = "expires=" + d.AddDays(exdays).ToUnixTimeMilliseconds(); 
            var cookie = name + "=" + value + ";" + expires + ";path=/";
            // Console.WriteLine(cookie);
            await jsRuntime.InvokeVoidAsync("eval", $"cookie='{cookie}'");
        }

        public async Task<string> Get(string name)
        { 
            var decodedCookie = await jsRuntime.InvokeAsync<string>("eval", "cookie");

            return decodedCookie;
        }
    }
} 