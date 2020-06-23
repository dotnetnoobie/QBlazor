using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace QBlazor
{ 
    public class Notifications : INotifications
    {
        private readonly IJSRuntime jsRuntime;

        public PermissionType Permission { get; set; }

        public Notifications(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task Create(string title )
        { 
            await Create(title, new NotificationOptions());
        }

        public async Task Create(string title, string body)
        { 
            var notificationOptions = new NotificationOptions { Body = body };
             
            await Create(title, notificationOptions);
        }

        public async Task Create(string title, NotificationOptions options)
        { 
            var notificationOptions = JsonSerializer.Serialize(options, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            Console.WriteLine(notificationOptions);

            await jsRuntime.InvokeVoidAsync("eval", "new Notification('" + title + "', " + notificationOptions + ");");
        }

        public async Task<PermissionType> RequestPermission()
        {
            string permission = await jsRuntime.InvokeAsync<string>("eval", "Notification.requestPermission().then(function(permission) { return permission; });");

            if (permission.Equals("granted", StringComparison.InvariantCultureIgnoreCase))
            {
                Permission = PermissionType.Granted;

                return Permission;
            }

            if (permission.Equals("denied", StringComparison.InvariantCultureIgnoreCase))
            {
                Permission = PermissionType.Denied;

                return Permission;
            }

            Permission = PermissionType.Default;

            return Permission;
        }
    }
}