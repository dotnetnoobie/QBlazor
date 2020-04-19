using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public class MetaData : IMetaData
    {
        private readonly IJSRuntime jsRuntime;

        public MetaData(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;

        }

        public async Task Update(IData data)
        {
            await Set("og:title", data.Title);
            await Set("og:description", data.Description);
            await Set("og:image", data.Image);

            async Task Set(string property, string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    await Delete(property);
                }
                else
                {
                    await Update(property, value);
                }
            }
        }

        private async Task Update(string property, string value)
        {
            await Delete(property);
            await Create(property, value);
        }

        private async Task Delete(string property)
        {
            if (await Exists(property))
            {
                await Remove(property);
            }
        }

        public async Task<bool> Exists(string property)
        {
            var element = await jsRuntime.InvokeAsync<object>("eval", $"document.head.querySelector('meta[property=\"{property}\"]')");
            return element != null;
        }

        public async Task Remove(string property)
        {
            await jsRuntime.InvokeVoidAsync("eval", $"document.head.removeChild(document.querySelector('meta[property=\"{property}\"]'))");
        }

        public async Task Create(string property, string value)
        {
            var element = $"<meta property=\"{property}\" content=\"{value}\" />";
            await jsRuntime.InvokeVoidAsync("eval", $"document.head.appendChild(document.createRange().createContextualFragment('{element}'))");
        }

        public async Task Tag(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = name.ToLowerInvariant();

                var element = await jsRuntime.InvokeAsync<object>("eval", $"document.head.querySelector('{name}')");
                if (element != null)
                {
                    //await jsRuntime.InvokeVoidAsync("eval", $"document.head.removeChild(document.querySelector('{name}'))");
                    await jsRuntime.InvokeVoidAsync("eval", $"document.head.querySelector('{name}').innerText = \"{value}\"");
                    return;
                }

                var tag = $"<{name}>{value}</{name}>";
                await jsRuntime.InvokeVoidAsync("eval", $"document.head.appendChild(document.createRange().createContextualFragment('{tag}'))");
            }
        }

        public async Task Favicon(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                var element = await jsRuntime.InvokeAsync<object>("eval", $"document.head.querySelector('link[rel=\"shortcut icon\"]')");
                if (element != null)
                {
                    //await jsRuntime.InvokeVoidAsync("eval", $"document.head.removeChild(document.querySelector('link[rel=\"shortcut icon\"]'))");
                    await jsRuntime.InvokeVoidAsync("eval", $"document.head.querySelector('link[rel=\"shortcut icon\"]').setAttribute(\"href\", \"{url}\")");
                    return;
                }

                var tag = $"<link rel=\"shortcut icon\" href=\"{url}\" />";
                await jsRuntime.InvokeVoidAsync("eval", $"document.head.appendChild(document.createRange().createContextualFragment('{tag}'))");
            }
        }
    }
}





// await jsRuntime.InvokeVoidAsync("eval", "document.querySelector('meta[name=\"Description\"]').setAttribute(\"content\", \"This is the contnent\");");

// await jsRuntime.InvokeVoidAsync("eval", "document.head.removeChild(document.querySelector('meta[name=\"description\"]'))");

// var x = await jsRuntime.InvokeAsync<object>("eval", "document.querySelector('meta[name=\"description\"]')");

// Console.WriteLine(x != null);

// var xx = await jsRuntime.InvokeAsync<object>("eval", "document.querySelector('meta[name=\"test\"]')");

// Console.WriteLine(xx != null);



// await jsRuntime.InvokeVoidAsync("document.querySelector('meta[name=\"Description\"]');");
// await jsRuntime.InvokeVoidAsync("document.querySelector('meta[name=\"Description\"]').setAttribute();", new[] { "content", "This is the contnent" });