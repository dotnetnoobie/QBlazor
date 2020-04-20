using Microsoft.JSInterop; 
using System.Threading.Tasks;

namespace QBlazor
{
    public class Navigator : INavigator
    {
        private IJSRuntime jsRuntime;

        public Navigator(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<string> AppCodeName()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "navigator.appCodeName");
        }

        public async Task<bool> CookieEnabled()
        {
            return await jsRuntime.InvokeAsync<bool>("eval", "navigator.cookieEnabled");
        }

        public async Task<string> Product()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "navigator.product");
        }

        public async Task<string> AppVersion()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "navigator.appVersion");
        }

        public async Task<string> Platform()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "navigator.platform");
        }

        public async Task<string> Language()
        {
            return await jsRuntime.InvokeAsync<string>("eval", "navigator.language");
        }

        public async Task<bool> OnLine()
        {
            return await jsRuntime.InvokeAsync<bool>("eval", "navigator.onLine");
        }

        public async Task<bool> javaEnabled()
        {
            return await jsRuntime.InvokeAsync<bool>("eval", "navigator.javaEnabled()");
        } 

        public async Task<string> UserAgent()
        {
            var sUsrAg = await jsRuntime.InvokeAsync<string>("eval", "navigator.userAgent");

            string sBrowser;
            if (sUsrAg.IndexOf("Firefox") > -1)
            {
                sBrowser = "Mozilla Firefox";
                // "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:61.0) Gecko/20100101 Firefox/61.0"
            }
            else if (sUsrAg.IndexOf("SamsungBrowser") > -1)
            {
                sBrowser = "Samsung Internet";
                // "Mozilla/5.0 (Linux; Android 9; SAMSUNG SM-G955F Build/PPR1.180610.011) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/9.4 Chrome/67.0.3396.87 Mobile Safari/537.36
            }
            else if (sUsrAg.IndexOf("Opera") > -1 || sUsrAg.IndexOf("OPR") > -1)
            {
                sBrowser = "Opera";
                // "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 OPR/57.0.3098.106"
            }
            else if (sUsrAg.IndexOf("Trident") > -1)
            {
                sBrowser = "Microsoft Internet Explorer";
                // "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; .NET4.0C; .NET4.0E; Zoom 3.6.0; wbx 1.0.0; rv:11.0) like Gecko"
            }
            else if (sUsrAg.IndexOf("Edge") > -1)
            {
                sBrowser = "Microsoft Edge";
                // "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299"
            }
            else if (sUsrAg.IndexOf("Chrome") > -1)
            {
                sBrowser = "Google Chrome or Chromium";
                // "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/66.0.3359.181 Chrome/66.0.3359.181 Safari/537.36"
            }
            else if (sUsrAg.IndexOf("Safari") > -1)
            {
                sBrowser = "Apple Safari";
                // "Mozilla/5.0 (iPhone; CPU iPhone OS 11_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/11.0 Mobile/15E148 Safari/604.1 980x1306"
            }
            else
            {
                sBrowser = "unknown";
            }

            return sBrowser;
        }
    }
}
