using Microsoft.JSInterop;
using System;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace QBlazor
{
    public class LocalStorage : Storage, ILocalStorage
    {
        public LocalStorage(IJSRuntime jsRuntime) : base(jsRuntime)
        {
            this.type = "local";
        }
    }
    public class SessionStorage : Storage, ISessionStorage
    {
        public SessionStorage(IJSRuntime jsRuntime) : base(jsRuntime)
        {
            this.type = "session";
        }
    }

    public abstract class Storage
    {
        protected string type;
        private readonly IJSRuntime jsRuntime;
        private readonly JsonSerializerOptions jsOptions;

        public Storage(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
            this.jsOptions = new JsonSerializerOptions();
            this.jsOptions.Converters.Add(new TimespanJsonConverter());
        }

        public async Task Clear() => await jsRuntime.InvokeAsync<object>($"{type}Storage.clear");

        public async Task<int> Length() => await jsRuntime.InvokeAsync<int>("eval", $"{type}Storage.length");

        public async Task<string> Key(int index) => await jsRuntime.InvokeAsync<string>($"{type}Storage.key", index);

        public async Task<bool> Contains<T>(Expression<Func<T>> expression)
            => await jsRuntime.InvokeAsync<bool>($"{type}Storage.hasOwnProperty", expression.GetKey());

        public async Task Remove<T>(Expression<Func<T>> expression)
            => await jsRuntime.InvokeAsync<string>($"{type}Storage.removeItem", expression.GetKey());

        public async Task Set<T>(Expression<Func<T>> expression)
            => await jsRuntime.InvokeVoidAsync($"{type}Storage.setItem", expression.GetKey(), JsonSerializer.Serialize(expression.GetValue(), jsOptions));

        public async Task<T> Get<T>(Expression<Func<T>> expression)
        {
            var json = await jsRuntime.InvokeAsync<string>($"{type}Storage.getItem", expression.GetKey());

            if (!string.IsNullOrEmpty(json))
            {
                return JsonSerializer.Deserialize<T>(json, jsOptions);
            }

            return default;
        }
    }
}