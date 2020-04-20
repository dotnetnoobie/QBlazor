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
            // d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            //var expires = "expires=" + d.toGMTString();
            var expires = "expires=" + d.AddDays(exdays).ToUnixTimeMilliseconds();


            //document.cookie = name + "=" + value + ";" + expires + ";path=/";
            var cookie = name + "=" + value + ";" + expires + ";path=/";
            Console.WriteLine(cookie);
            await jsRuntime.InvokeVoidAsync("eval", $"cookie='{cookie}'");
        }

        public async Task<string> Get(string name)
        {
            //  var decodedCookie = await jsRuntime.InvokeAsync<string>("eval", "decodeURIComponent(document.cookie)");
            var decodedCookie = await jsRuntime.InvokeAsync<string>("eval", "cookie");

            return decodedCookie;
        }
    }
}



//function getCookie(cname)
//{
//    var name = cname + "=";
//    var decodedCookie = decodeURIComponent(document.cookie);
//    var ca = decodedCookie.split(';');
//    for (var i = 0; i < ca.length; i++)
//    {
//        var c = ca[i];
//        while (c.charAt(0) == ' ')
//        {
//            c = c.substring(1);
//        }
//        if (c.indexOf(name) == 0)
//        {
//            return c.substring(name.length, c.length);
//        }
//    }
//    return "";
//}
